using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            // Crear una vista previa de la tarjeta sin guardar
            Bitmap bmp = new Bitmap(268, 343);
            panelTarjeta.DrawToBitmap(bmp, new Rectangle(0, 0, 268, 343));

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
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            var soloDigitos = new string(txtTelefono.Text.Where(char.IsDigit).ToArray());
            if (soloDigitos.Length != 10)
            {
                MessageBox.Show("El número de teléfono debe tener exactamente 10 dígitos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
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

            // Guardar la tarjeta como imagen
            try
            {
                panelTarjeta.Invalidate();
                Bitmap bmp = new Bitmap(268, 343);
                panelTarjeta.DrawToBitmap(bmp, new Rectangle(0, 0, 268, 343));

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
            g.Clear(Color.White);

            Font font = new Font("Arial", 10, FontStyle.Bold); // Letra más pequeña para que quepa bien
            Brush brush = Brushes.Black;

            int panelWidth = 268;
            int currentY = 10;

            // 1. Logo
            if (picLogo.Image != null)
            {
                int logoWidth = 60;
                int logoHeight = 60;
                g.DrawImage(picLogo.Image, new Rectangle(10, 10, logoWidth, logoHeight));
            }

            // 2. Foto del empleado (centrada)
            if (picFoto.Image != null)
            {
                int fotoWidth = 90;
                int fotoHeight = 110;
                int fotoX = (panelWidth - fotoWidth) / 2;
                g.DrawImage(picFoto.Image, new Rectangle(fotoX, currentY, fotoWidth, fotoHeight));
                currentY += fotoHeight + 10;
            }

            // 3. Datos centrados
            string telefonoFormateado = FormatearTelefono(txtTelefono.Text);
            string[] datos = {
        "Nombre: " + txtNombre.Text,
        "Teléfono: " + telefonoFormateado,
        txtPosicion.Text
    };

            foreach (string dato in datos)
            {
                SizeF textoSize = g.MeasureString(dato, font);
                float textoX = (panelWidth - textoSize.Width) / 2;
                g.DrawString(dato, font, brush, textoX, currentY);
                currentY += (int)textoSize.Height + 5;
            }

            // 4. Borde
            g.DrawRectangle(Pens.Black, 0, 0, 267, 342); // 1 píxel menos por el borde
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
    }

}
