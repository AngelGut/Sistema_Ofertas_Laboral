using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CpPresentacion
{
    public partial class Carnet : MaterialForm
    {
        public Carnet()
        {
            InitializeComponent();
            panelTarjeta.Size = new Size(268, 343);
            materialTabControl1.SelectedIndex = 6;
            // Asociar eventos para validar entrada en tiempo real
            txtNombre.KeyPress += TxtSoloLetras_KeyPress;
            txtTelefono.KeyPress += TxtSoloNumeros_KeyPress;
            txtPosicion.KeyPress += TxtSoloLetras_KeyPress;
        }

        /* Conecta este handler en el diseñador (⚡ SelectedIndexChanged) */
        /* Conecta este handler en el diseñador (⚡ SelectedIndexChanged) */
        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await NavegarA(materialTabControl1.SelectedIndex);
        }

        private async Task NavegarA(int idx)
        {
            // A) ¿A qué ventana ir?
            Form destino = idx switch
            {
                0 => Application.OpenForms.OfType<Menu>()
                                          .FirstOrDefault() ?? new Menu(),

                // Evitamos duplicar instancias si ya estamos ahí
                1 => this is cpOfertas ? this : new cpOfertas(),
                2 => this is cpEmpresa ? this : new cpEmpresa(),
                3 => this is cpPostulante ? this : new cpPostulante(),
                4 => this is cpAsignarEmpleo ? this : new cpAsignarEmpleo(),
                5 => this is cpHistorialMensajes ? this : new cpHistorialMensajes(),
                6 => this is Carnet ? this : new Carnet(),
                7 => this is cpRegistro ? this : new cpRegistro(),
                _ => null
            };

            // B) Si ya estamos en el destino, no hacemos nada
            if (destino == null || destino == this) return;

            // C) Mostrar el nuevo formulario
            destino.Show();

            // D) Menu nunca se cierra; los demás se liberan
            if (this is Menu)
                this.Hide();     // se mantiene en memoria
            else
                this.Dispose();  // libera recursos

            await Task.Delay(180); // Pausa opcional, transición suave
        }
        /* ── Aquí sigue tu lógica propia: botones, validaciones, etc. ── */
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            // Asegúrate que el panel se haya renderizado completamente
            panelTarjeta.Refresh(); // Fuerza repintado

            // Usa el tamaño real del panel
            int ancho = panelTarjeta.Width;
            int alto = panelTarjeta.Height;

            // Crear Bitmap del mismo tamaño
            Bitmap bmp = new Bitmap(ancho, alto);
            panelTarjeta.DrawToBitmap(bmp, new Rectangle(0, 0, ancho, alto));

            Form vistaPreviaForm = new Form
            {
                Text = "Vista previa de la tarjeta",
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(bmp.Width, bmp.Height)
            };

            PictureBox pb = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = bmp,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            vistaPreviaForm.Controls.Add(pb);
            vistaPreviaForm.ShowDialog();
        }

        private void btnGuardarTargeta_Click(object sender, EventArgs e)
        {

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPosicion.Text))
            {
                MessageBox.Show("El campo Posición no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPosicion.Focus();
                return;
            }
            if (picFoto.Image == null)
            {
                MessageBox.Show("Debe cargar una foto antes de guardar la tarjeta.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El campo Correo no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }
            else if (!EsCorreoValido(txtCorreo.Text))

                try
            {
                panelTarjeta.Invalidate();
                Bitmap bmp = new Bitmap(panelTarjeta.Width, panelTarjeta.Height);
                panelTarjeta.DrawToBitmap(bmp, new Rectangle(0, 0, panelTarjeta.Width, panelTarjeta.Height));
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Imagen PNG|*.png";
                sfd.FileName = "Tarjeta_ID.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName);
                    MessageBox.Show("Tarjeta guardada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la tarjeta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelTarjeta_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int width = panelTarjeta.Width;
            int height = panelTarjeta.Height;

            // 1. FONDO DIVIDIDO EN DOS
            int mitad = height / 2;
            g.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 64)), 0, 0, width, mitad); // parte superior azul oscuro
            g.FillRectangle(Brushes.Gray, 0, mitad, width, height - mitad); // parte inferior gris

            // 2. LOGO
            if (picLogo.Image != null)
            {
                int logoAncho = 150;
                int logoAlto = 150;
                int logoX = (width - logoAncho) / 2;
                int logoY = 10;

                float opacity = 0.2f;

                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(picLogo.Image,
                    new Rectangle(logoX, logoY, logoAncho, logoAlto),
                    0, 0, picLogo.Image.Width, picLogo.Image.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }

            // 3. FOTO EN CÍRCULO
            if (picFoto.Image != null)
            {
                int fotoSize = 100;
                int fotoX = (width - fotoSize) / 2;
                int fotoY = mitad - (fotoSize / 2);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(fotoX, fotoY, fotoSize, fotoSize);
                    g.SetClip(path);
                    g.DrawImage(picFoto.Image, new Rectangle(fotoX, fotoY, fotoSize, fotoSize));
                    g.ResetClip();
                }

                g.DrawEllipse(new Pen(Color.Gray, 2), fotoX, fotoY, fotoSize, fotoSize);
            }

            // 4. TEXTO: NOMBRE, POSICIÓN
            string nombre = txtNombre.Text;
            string posicion = txtPosicion.Text;

            Font fontNombre = new Font("Arial", 10, FontStyle.Bold);
            Font fontPosicion = new Font("Arial", 10, FontStyle.Italic);
            Brush blanco = Brushes.White;
            Brush morado = new SolidBrush(Color.FromArgb(152, 121, 221));

            SizeF nombreSize = g.MeasureString(nombre, fontNombre);
            SizeF posicionSize = g.MeasureString(posicion, fontPosicion);

            float textoY = mitad + 60;

            g.DrawString(nombre, fontNombre, blanco, (width - nombreSize.Width) / 2, textoY);
            textoY += nombreSize.Height + 2;
            g.DrawString(posicion, fontPosicion, morado, (width - posicionSize.Width) / 2, textoY);

            // 5. DATOS INFERIORES

            string telefonoFormateado = FormatearTelefono(txtTelefono.Text);
            string correo = txtCorreo.Text; // Aquí se toma el correo real

            Font fontLabel = new Font("Arial", 8, FontStyle.Bold);
            Font fontDato = new Font("Arial", 8);
            Brush blancoDatos = Brushes.White;

            float baseY = textoY + posicionSize.Height + 15;
            float espacio = 3;

            // Línea 1: "Phone:"
            SizeF sizePhoneLabel = g.MeasureString("Phone:", fontLabel);
            float xPhoneLabel = (width - sizePhoneLabel.Width) / 2;
            g.DrawString("Phone:", fontLabel, blancoDatos, xPhoneLabel, baseY);
            baseY += sizePhoneLabel.Height + espacio;

            // Línea 2: número de teléfono
            SizeF sizePhone = g.MeasureString(telefonoFormateado, fontDato);
            float xPhone = (width - sizePhone.Width) / 2;
            g.DrawString(telefonoFormateado, fontDato, blancoDatos, xPhone, baseY);
            baseY += sizePhone.Height + espacio + 5;

            // Línea 3: "E-Mail:"
            SizeF sizeEmailLabel = g.MeasureString("E-Mail:", fontLabel);
            float xEmailLabel = (width - sizeEmailLabel.Width) / 2;
            g.DrawString("E-Mail:", fontLabel, blancoDatos, xEmailLabel, baseY);
            baseY += sizeEmailLabel.Height + espacio;

            // Línea 4: dirección de correo
            SizeF sizeEmail = g.MeasureString(correo, fontDato);
            float xEmail = (width - sizeEmail.Width) / 2;
            g.DrawString(correo, fontDato, blancoDatos, xEmail, baseY);
        }

        // ========================== VALIDACIONES ==========================

        private void TxtSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en este campo.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números en este campo.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ========================== UTILIDADES ==========================

        private string FormatearTelefono(string telefono)
        {
            var soloDigitos = new string(telefono.Where(char.IsDigit).ToArray());

            if (soloDigitos.Length == 10)
            {
                return string.Format("({0}) {1}-{2}",
                    soloDigitos.Substring(0, 3),
                    soloDigitos.Substring(3, 3),
                    soloDigitos.Substring(6, 4));
            }
            else if (soloDigitos.Length == 7)
            {
                return string.Format("{0}-{1}",
                    soloDigitos.Substring(0, 3),
                    soloDigitos.Substring(3, 4));
            }
            else
            {
                return telefono;
            }
        }

        private bool EsCorreoValido(string correo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }


}
