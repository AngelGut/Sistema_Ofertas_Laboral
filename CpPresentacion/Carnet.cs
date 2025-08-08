using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CpPresentacion.Asistencia;   // contiene IReadOnlyContainer y las extensiones

namespace CpPresentacion
{
    public partial class Carnet : MaterialForm, IReadOnlyContainer
    {
        public Control Container => this;
        private FormBoton _formBoton; // ← switch flotante

        public Carnet()
        {
            InitializeComponent();
            panelTarjeta.Size = new Size(268, 440);
            materialTabControl1.SelectedIndex = 6;
            // Asociar eventos para validar entrada en tiempo real
            txtNombre.KeyPress += TxtSoloLetras_KeyPress;
            maskTelefono.KeyPress += TxtSoloNumeros_KeyPress;
            txtPosicion.KeyPress += TxtSoloLetras_KeyPress;

            // 1) Arrancar bloqueado
            this.SetReadOnly(true);

            // 2) Mini-form para decidir estado inicial
            bool startInEdit = false;
            using (var dlg = new frmModoVisualizacion())
            {
                if (dlg.ShowDialog() == DialogResult.OK &&
                    dlg.Resultado == frmModoVisualizacion.ResultadoSeleccion.Editar)
                {
                    startInEdit = true;
                }
            }

            // 3) Aplicar estado inicial
            this.SetReadOnly(!startInEdit);

            // 4) Abrir switch flotante (siempre activo)
            AbrirFormBoton(startInEdit);

            // 5) Cerrar flotante cuando cierre este form
            this.FormClosed += (s, e) =>
            {
                if (_formBoton != null && !_formBoton.IsDisposed) _formBoton.Close();
                _formBoton = null;
            };
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
                // Siempre nueva instancia de Menu
                0 => new Menu(),
                1 => this is cpOfertas ? this : new cpOfertas(),
                2 => this is cpEmpresa ? this : new cpEmpresa(),
                3 => this is cpPostulante ? this : new cpPostulante(),
                4 => this is cpAsignarEmpleo ? this : new cpAsignarEmpleo(),
                5 => this is cpHistorialMensajes ? this : new cpHistorialMensajes(),
                6 => this is Carnet ? this : new Carnet(),
                7 => this is cpRegistro ? this : new cpRegistro(),
                8 => this is cpHistorialPostulaciones ? this : new cpHistorialPostulaciones(),
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

            // Asegurarnos de que la UI repinte inmediatamente:
            destino.BringToFront();
            destino.Activate();


        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
        //aqui empieza lo mio 

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            //OpenFileDialog es lo que permite que el usuario pueda seleccionar un archivo desde su computadora 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(ofd.FileName);
            }
        }
        //TODO:Se utilisa este metodo porque  no devuelve ningun valor 
        private async void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            //llmada asincrona 
            // Mostrar ventana de carga
            Form ventanaCarga = CrearVentanaCarga("Generando vista previa...");
            ventanaCarga.Show();
            ventanaCarga.Refresh();

            await Task.Delay(1200); // Simula procesamiento
            ventanaCarga.Close();

            // Crear bitmap de la tarjeta
            panelTarjeta.Refresh();
            int ancho = panelTarjeta.Width;
            int alto = panelTarjeta.Height;
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

        private async void btnGuardarTargeta_Click(object sender, EventArgs e)
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
            {
                MessageBox.Show("El correo electrónico no es válido. Debe tener un formato como: ejemplo@dominio.com", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(maskTelefono.Text))
            {
                MessageBox.Show("El campo Teléfono no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskTelefono.Focus();
                return;
            }

            // Mostrar ventana de carga
            Form ventanaCarga = CrearVentanaCarga();
            ventanaCarga.Show();

            // Esperar simulando procesamiento
            await Task.Delay(1500);

            // Cerrar ventana de carga
            ventanaCarga.Close();
            //guarda la targeta 
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
            // la clase Graphics se usa para dibujar en la pantalla
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int width = panelTarjeta.Width;
            int height = panelTarjeta.Height;

            // FONDO DIVIDIDO EN DOS
            int mitad = height / 2;
            g.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 64)), 0, 0, width, mitad); // parte superior azul oscuro
            g.FillRectangle(Brushes.Gray, 0, mitad, width, height - mitad); // parte inferior gris

            //  LOGO
            if (picLogo.Image != null)
            {
                int logoAncho = 200;
                int logoAlto = 200;
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

            //  FOTO EN CÍRCULO
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

            //  TEXTO: NOMBRE, POSICIÓN
            string nombre = txtNombre.Text;
            string posicion = txtPosicion.Text;

            Font fontNombre = new Font("Arial", 11, FontStyle.Bold);
            Font fontPosicion = new Font("Arial", 11, FontStyle.Italic);
            Brush blanco = Brushes.White;
            Brush morado = new SolidBrush(Color.DarkBlue);

            SizeF nombreSize = g.MeasureString(nombre, fontNombre);
            SizeF posicionSize = g.MeasureString(posicion, fontPosicion);

            float textoY = mitad + 60;

            g.DrawString(nombre, fontNombre, blanco, (width - nombreSize.Width) / 2, textoY);
            textoY += nombreSize.Height + 2;
            g.DrawString(posicion, fontPosicion, morado, (width - posicionSize.Width) / 2, textoY);

            //  DATOS INFERIORES

            string telefonoFormateado = maskTelefono.Text;
            string correo = txtCorreo.Text; // Aquí se toma el correo real

            Font fontLabel = new Font("Arial", 9, FontStyle.Bold);
            Font fontDato = new Font("Arial", 9);
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



        private bool EsCorreoValido(string correo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            // Mostrar ventana de carga
            Form ventanaCarga = CrearVentanaCarga("Preparando impresión...");
            ventanaCarga.Show();
            ventanaCarga.Refresh();

            await Task.Delay(1200); // Simula procesamiento

            ventanaCarga.Close();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog(); // Muestra vista previa antes de imprimir
        }

        //metodo para que se guarde con el formato de imprecion 

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Establecer la unidad en pulgadas y usar 300 DPI
            g.PageUnit = GraphicsUnit.Inch;

            // CR80 size = 3.375 in x 2.125 in
            float anchoInch = 2.125f;
            float altoInch = 3.375f;

            // Coordenadas de inicio (con márgenes)
            float startX = 0.5f;
            float startY = 0.5f;

            RectangleF rect = new RectangleF(startX, startY, anchoInch, altoInch);

            // Crear bitmap del panel
            Bitmap bmp = new Bitmap(panelTarjeta.Width, panelTarjeta.Height);
            panelTarjeta.DrawToBitmap(bmp, new Rectangle(0, 0, panelTarjeta.Width, panelTarjeta.Height));

            // Dibujar el carnet escalado para que se imprima en tamaño real
            g.DrawImage(bmp, rect);
        }

        private Form CrearVentanaCarga(string mensaje = "Procesando...")
        {
            Form carga = new Form
            {
                Size = new Size(220, 100),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                ControlBox = false,
                Text = "Espere..."
            };

            Label lbl = new Label
            {
                Text = mensaje,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            carga.Controls.Add(lbl);
            return carga;
        }


        private void maskTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskTelefono_Click_1(object sender, EventArgs e)
        {
            maskTelefono.SelectionStart = 0;
        }

        private void AbrirFormBoton(bool startInEdit)
        {
            if (_formBoton != null && !_formBoton.IsDisposed) return;

            _formBoton = new FormBoton(this, startInEdit)
            {
                StartPosition = FormStartPosition.Manual,
                TopMost = true
            };

            void Reposicionar()
            {
                if (_formBoton == null || _formBoton.IsDisposed) return;

                // Posición del form principal en pantalla
                var p = this.PointToScreen(Point.Empty);

                // AFUERA, pegado al borde derecho y centrado vertical
                int x = p.X + this.Width;                               // justo al lado derecho
                int y = p.Y + (this.Height - _formBoton.Height) / 2;    // centrado vertical

                // Mantener visible en el monitor del form (evita que se “corte”)
                var wa = Screen.FromControl(this).WorkingArea;
                x = Math.Min(Math.Max(x, wa.Left), wa.Right - _formBoton.Width);
                y = Math.Min(Math.Max(y, wa.Top), wa.Bottom - _formBoton.Height);

                _formBoton.Location = new Point(x, y);
            }

            Reposicionar();
            this.Move += (s, e) => Reposicionar();
            this.Resize += (s, e) => Reposicionar();

            _formBoton.FormClosed += (s, e) => _formBoton = null;
            _formBoton.Show(this); // owner
        }
    }
}
