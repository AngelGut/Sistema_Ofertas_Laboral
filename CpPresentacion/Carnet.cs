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
        // Tamaño CR80 en pulgadas
        const float CARD_W_IN = 2.125f;   // 2.125 in
        const float CARD_H_IN = 3.375f;   // 3.375 in
        const int EXPORT_DPI = 300;       // DPI fijo para archivo/impresión

        int Px(float inches, int dpi) => (int)Math.Round(inches * dpi);

        public Control Container => this;
        private FormBoton _formBoton; // ← switch flotante

        public Carnet()
        {
            InitializeComponent();
            this.Load += Carnet_Load;
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
            var ventanaCarga = CrearVentanaCarga("Generando vista previa...");
            ventanaCarga.Show(); ventanaCarga.Refresh();
            await Task.Delay(600);
            ventanaCarga.Close();

            using var bmp = RenderCarnetBitmap(200); // dpi menor para preview
            var vistaPreviaForm = new Form
            {
                Text = "Vista previa de la tarjeta",
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size((int)(bmp.Width * 0.7), (int)(bmp.Height * 0.7))
            };
            var pb = new PictureBox { Dock = DockStyle.Fill, Image = (Bitmap)bmp.Clone(), SizeMode = PictureBoxSizeMode.Zoom };
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
                using var bmp = RenderCarnetBitmap(EXPORT_DPI);
                using var sfd = new SaveFileDialog { Filter = "Imagen PNG|*.png", FileName = "Tarjeta_ID.png" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName, ImageFormat.Png);
                    MessageBox.Show("Tarjeta guardada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la tarjeta: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelTarjeta_Paint(object sender, PaintEventArgs e)
        {
            DrawCarnet(e.Graphics, panelTarjeta.Width, panelTarjeta.Height,
             picLogo.Image, picFoto.Image,
             txtNombre.Text, txtPosicion.Text,
             maskTelefono.Text, txtCorreo.Text);
        }

        // ======== DIBUJO V2: fuentes y márgenes proporcionales + clamp al borde ========

        //TODO:esto dibuja todo en el panel para guardarlo
        private void DrawCarnet(Graphics g, int width, int height,
                                Image logo, Image foto,
                                string nombre, string posicion, string telefono, string correo)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Márgenes/constantes
            int m = (int)(height * 0.05f);          // 5% de margen inferior/superior
            int mitad = height / 2;
            int contentLeft = (int)(width * 0.06f);
            int contentRight = width - contentLeft;
            int contentWidth = contentRight - contentLeft;
            float bottomLimit = height - m;

            // Fondos
            using (var top = new SolidBrush(Color.FromArgb(25, 25, 64)))
                g.FillRectangle(top, 0, 0, width, mitad);
            g.FillRectangle(Brushes.Gray, 0, mitad, width, height - mitad);

            // Logo tenue
            if (logo != null)
            {
                int lw = (int)(width * 0.72f);
                int lh = lw;
                int lx = (width - lw) / 2;
                int ly = (int)(height * 0.03f);

                var cm = new System.Drawing.Imaging.ColorMatrix(); cm.Matrix33 = 0.18f;
                var ia = new System.Drawing.Imaging.ImageAttributes(); ia.SetColorMatrix(cm);
                g.DrawImage(logo, new Rectangle(lx, ly, lw, lh),
                    0, 0, logo.Width, logo.Height, GraphicsUnit.Pixel, ia);
            }

            // Foto circular
            if (foto != null)
            {
                int fs = (int)(Math.Min(width, height) * 0.23f);
                int fx = (width - fs) / 2;
                int fy = mitad - fs / 2;
                using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    gp.AddEllipse(fx, fy, fs, fs);
                    g.SetClip(gp);
                    g.DrawImage(foto, new Rectangle(fx, fy, fs, fs));
                    g.ResetClip();
                }
                using var pen = new Pen(Color.Gray, Math.Max(2f, width / 220f));
                g.DrawEllipse(pen, fx, fy, fs, fs);
            }

            // Fuentes base (en px, relativas al alto)
            float baseNombre = height * 0.07f;   // antes 0.10–0.08 era demasiado
            float basePos = height * 0.055f;
            float baseLbl = height * 0.045f;
            float baseDato = height * 0.045f;

            // Ajustar DINÁMICAMENTE para que quepan
            using var fNombre = FitFont(g, nombre, "Arial", FontStyle.Bold, baseNombre, (int)(contentWidth * 0.92f));
            using var fPos = FitFont(g, posicion, "Arial", FontStyle.Italic, basePos, (int)(contentWidth * 0.92f));
            using var fLbl = new Font("Arial", baseLbl, FontStyle.Bold, GraphicsUnit.Pixel);
            using var fDato = new Font("Arial", baseDato, FontStyle.Regular, GraphicsUnit.Pixel);
            using var azulOsc = new SolidBrush(Color.DarkBlue);

            // Bloque de textos inferior
            float y = mitad + (height * 0.12f);   // sube un poco el bloque
            float lineGap = height * 0.012f;

            // Nombre
            var sNom = g.MeasureString(nombre, fNombre);
            if (y + sNom.Height <= bottomLimit)
            {
                g.DrawString(nombre, fNombre, Brushes.White, (width - sNom.Width) / 2, y);
                y += sNom.Height + lineGap;
            }

            // Posición
            var sPos = g.MeasureString(posicion, fPos);
            if (y + sPos.Height <= bottomLimit)
            {
                g.DrawString(posicion, fPos, azulOsc, (width - sPos.Width) / 2, y);
                y += sPos.Height + lineGap * 1.5f;
            }

            // Phone label
            var sPL = g.MeasureString("Phone:", fLbl);
            if (y + sPL.Height <= bottomLimit)
            {
                g.DrawString("Phone:", fLbl, Brushes.White, (width - sPL.Width) / 2, y);
                y += sPL.Height + lineGap;
            }

            // Phone
            var sP = g.MeasureString(telefono, fDato);
            if (y + sP.Height <= bottomLimit)
            {
                g.DrawString(telefono, fDato, Brushes.White, (width - sP.Width) / 2, y);
                y += sP.Height + lineGap * 1.5f;
            }

            // Email label
            var sEL = g.MeasureString("E-Mail:", fLbl);
            if (y + sEL.Height <= bottomLimit)
            {
                g.DrawString("E-Mail:", fLbl, Brushes.White, (width - sEL.Width) / 2, y);
                y += sEL.Height + lineGap;
            }

            // Email
            var sE = g.MeasureString(correo, fDato);
            if (y + sE.Height <= bottomLimit)
            {
                g.DrawString(correo, fDato, Brushes.White, (width - sE.Width) / 2, y);
            }
        }
        //TODO:bitmad esto es para que se guarde con formato
        private Bitmap RenderCarnetBitmap(int dpi)
        {
            int w = Px(CARD_W_IN, dpi);   // 2.125" → 638 px @300dpi
            int h = Px(CARD_H_IN, dpi);   // 3.375" → 1013 px @300dpi
            var bmp = new Bitmap(w, h);
            bmp.SetResolution(dpi, dpi);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black); // opcional
                DrawCarnet(g, w, h,
                           picLogo.Image, picFoto.Image,
                           txtNombre.Text, txtPosicion.Text,
                           maskTelefono.Text, txtCorreo.Text);
            }
            return bmp;
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
        //TODO:esto es para los eventos asincronos 
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

        private void Carnet_Load(object sender, EventArgs e)
        {
            float ratio = CARD_W_IN / CARD_H_IN; // ≈ 0.6296
            int targetH = 440;
            int targetW = (int)(targetH * ratio); // ≈ 277 px

            panelTarjeta.Size = new Size(targetW, targetH);
            panelTarjeta.MinimumSize = panelTarjeta.MaximumSize = panelTarjeta.Size;
            panelTarjeta.Invalidate();
        }

        // ↓↓↓ helper para ajustar tamaño de fuente hasta que quepa en el ancho dado
        private Font FitFont(Graphics g, string text, string family, FontStyle style, float startPx, int maxWidth)
        {
            float size = startPx;
            Font f = new Font(family, size, style, GraphicsUnit.Pixel);
            SizeF s = g.MeasureString(text, f);

            // baja de a poco hasta que quepa (o llegue a un mínimo razonable)
            while (s.Width > maxWidth && size > 10f)
            {
                f.Dispose();
                size -= 1.0f;
                f = new Font(family, size, style, GraphicsUnit.Pixel);
                s = g.MeasureString(text, f);
            }
            return f; // caller dispone
        }
    }
}
