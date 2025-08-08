using CpNegocio.Empresas_y_Postulantes;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using CpNegocio.servicio;
using CpNegocio.servicios;
using CpNegocio.Oferta;
using CpPresentacion.Asistencia;

namespace CpPresentacion
{
    public partial class cpAsignarEmpleo : MaterialForm, IReadOnlyContainer
    {
        private FormBoton _formBoton;  // switch flotante

        // Implementación requerida por IReadOnlyContainer
        public Control Container => this;
        private DataTable tablaPostulantes;
        private DataTable tablaEmpresas;

        // Variables para IDs seleccionados
        private int idPostulanteSeleccionado = -1;
        private int idOfertaSeleccionada = -1;

        public cpAsignarEmpleo()
        {
            InitializeComponent();
            //Metodo de personalizacion del datagridview
            PersonalizarDataGridView();
            PersonalizarDataGridView2();
            materialTabControl1.SelectedIndex = 4;

            // Configuración inicial de MaterialSkin
            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Configuración de estilo para DataGridViews
            dgvPostulantes.EnableHeadersVisualStyles = false;
            dgvPostulantes.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvEmpresas.EnableHeadersVisualStyles = false;
            dgvEmpresas.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;

            CargarCombos();

            // Asignar eventos
            this.Load += new EventHandler(cpAsignarEmpleo_Load);

            // Eventos para filtros de Empresas
            btnBuscar2.Click += btnBuscar2_Click;
            cmbFiltroArea.SelectedIndexChanged += cmbFiltroArea_SelectedIndexChanged;
            txtBuscarID.KeyPress += txtBuscarID_KeyPress;

            // Evento Click del botón para filtrar postulantes
            btnBuscarID.Click += btnBuscarID_Click;

            // Se asigna el evento KeyPress al txtBuscarDNI
            txtBuscarDNI.KeyPress += txtBuscarDNI_KeyPress;

            // Se modifica cmbFiltroEmpresa para que solo tenga la opción "ID Oferta".
            cmbFiltroEmpresa.Items.Clear();
            cmbFiltroEmpresa.Items.Add("ID Oferta");
            cmbFiltroEmpresa.SelectedIndex = 0; // Se selecciona por defecto la única opción.

            // Limitar entrada a dígitos en los textboxes manuales (opcional)
            txboxIdPersona.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar)) ev.Handled = true;
            };
            texboxIdOferta.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar)) ev.Handled = true;
            };

            // 1) Bloquear todos los controles por defecto (modo "Ver")
            // 1) Arrancar bloqueado (modo Ver)
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

            // (opcional) permitir selección en grillas aunque esté en "Ver"
            // dgvPostulantes.Enabled = true;
            // dgvEmpresas.Enabled = true;

            // 4) Abrir switch flotante (siempre activo)
            AbrirFormBoton(startInEdit);

            // 5) Cerrar el flotante cuando se cierre este form
            this.FormClosed += (s, e) =>
            {
                if (_formBoton != null && !_formBoton.IsDisposed) _formBoton.Close();
                _formBoton = null;
            };
        }
        //TODO: Metodo para cargar la informacion de combobox
        private void CargarCombos()
        {
            // Cargar cmbFiltroArea con todas las áreas laborales
            cmbFiltroArea.Items.Clear();
            cmbFiltroArea.Items.Add("Todas");
            foreach (var area in AreaLaboralProvider.GetAll())
            {
                cmbFiltroArea.Items.Add(area);
            }
            cmbFiltroArea.SelectedIndex = 0;

            // Cargar cmbNuevo para el filtro de postulantes
            cmbNuevo.Items.Clear();
            cmbNuevo.Items.Add("Todas");
            cmbNuevo.Items.Add("ID");
            cmbNuevo.Items.Add("Dni");
            cmbNuevo.Items.Add("Nombre");
            cmbNuevo.SelectedIndex = 0;
        }

        
        //TODO: Método de carga del formulario. Inicia la carga de datos.
        
        private void cpAsignarEmpleo_Load(object sender, EventArgs e)
        {
            CargarOfertas();
            MostrarPostulantes();
        }

        
        //TODO: Carga los datos de las ofertas de empleo en el DataGridView de empresas.
      
        private void CargarOfertas()
        {
            try
            {
                var negocioOferta = new NOferta();
                tablaEmpresas = negocioOferta.ObtenerOfertas();
                dgvEmpresas.DataSource = tablaEmpresas;

                if (tablaEmpresas.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron ofertas de empleo para mostrar. Por favor, asegúrate de haber registrado ofertas y empresas en las secciones correspondientes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Actualización de los encabezados de las columnas.
                if (dgvEmpresas.Columns.Contains("NombreEmpresa")) dgvEmpresas.Columns["NombreEmpresa"].HeaderText = "Empresa";
                if (dgvEmpresas.Columns.Contains("NombrePuesto")) dgvEmpresas.Columns["NombrePuesto"].HeaderText = "Puesto";
                if (dgvEmpresas.Columns.Contains("Area")) dgvEmpresas.Columns["Area"].HeaderText = "Área Laboral";
                if (dgvEmpresas.Columns.Contains("Tipo")) dgvEmpresas.Columns["Tipo"].HeaderText = "Tipo"; // <-- SE ASEGURA DE QUE SE MUESTRE EL TIPO
                if (dgvEmpresas.Columns.Contains("Descripcion")) dgvEmpresas.Columns["Descripcion"].HeaderText = "Descripción";
                if (dgvEmpresas.Columns.Contains("Creditos")) dgvEmpresas.Columns["Creditos"].HeaderText = "Créditos";
                if (dgvEmpresas.Columns.Contains("Salario")) dgvEmpresas.Columns["Salario"].HeaderText = "Salario"; // <-- AGREGADO PARA CLARIDAD

                // Oculta las columnas que no son necesarias
                if (dgvEmpresas.Columns.Contains("EmpresaId")) dgvEmpresas.Columns["EmpresaId"].Visible = false;
                if (dgvEmpresas.Columns.Contains("RNC")) dgvEmpresas.Columns["RNC"].Visible = false;
                if (dgvEmpresas.Columns.Contains("Descripcion")) dgvEmpresas.Columns["Descripcion"].Visible = false;
                if (dgvEmpresas.Columns.Contains("Requisitos")) dgvEmpresas.Columns["Requisitos"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ofertas: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //TODO: Metodo que muestra los postulantes del en datagridview  con los datos que se registran en el form cpPostulantes
        private void MostrarPostulantes()
        {
            var negocioPostulante = new NPostulante();
            tablaPostulantes = negocioPostulante.Mostrar();
            dgvPostulantes.DataSource = tablaPostulantes;
        }

        
        //TODO: Metodo que filtra los postulantes según el criterio seleccionado en el combobox cmbNuevo.
       
        private void FiltrarPostulantes(string texto)
        {
            if (tablaPostulantes == null) return;
            string filtroSeleccionado = cmbNuevo.SelectedItem?.ToString();

            // Si la opción es "Todas" o el texto está vacío, se muestran todos los postulantes.
            if (filtroSeleccionado == "Todas" || string.IsNullOrWhiteSpace(texto))
            {
                dgvPostulantes.DataSource = tablaPostulantes;
                return;
            }

            DataView vista = new DataView(tablaPostulantes);
            string filtro = "";
            switch (filtroSeleccionado)
            {
                case "ID":
                    filtro = $"Convert(Id, 'System.String') LIKE '%{texto}%'";
                    break;
                case "Dni":
                    filtro = $"Dni LIKE '%{texto}%'";
                    break;
                case "Nombre":
                    filtro = $"Nombre LIKE '%{texto}%'";
                    break;
            }

            vista.RowFilter = filtro;
            dgvPostulantes.DataSource = vista;

            // Se muestra un mensaje si no se encuentran resultados
            if (vista.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados para la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPostulantes.DataSource = tablaPostulantes; // Vuelve a mostrar todos los postulantes
            }
        }

        
        //TODO: Metodo que aplica los filtros de Área e ID de Oferta en el DataGridView de empresas.
        
        private void AplicarFiltrosEmpresas()
        {
            if (tablaEmpresas == null) return;

            DataView vista = new DataView(tablaEmpresas);
            string filtroFinal = "";

            // Lógica para el filtro de área (si se selecciona algo diferente a "Todas")
            string areaSeleccionada = cmbFiltroArea.SelectedItem?.ToString();
            if (areaSeleccionada != "Todas")
            {
                filtroFinal = $"Area = '{areaSeleccionada.Replace("'", "''")}'";
            }

            // Lógica para el filtro por ID de Oferta
            string textoBusqueda = txtBuscarID.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                // Se agrega un "AND" si ya existe un filtro de área
                if (!string.IsNullOrEmpty(filtroFinal))
                {
                    filtroFinal += " AND ";
                }
                // Se filtra por el ID de la oferta
                filtroFinal += $"Convert(idOferta, 'System.String') LIKE '%{textoBusqueda}%'";
            }

            // Aplicar el filtro final si no está vacío
            if (!string.IsNullOrEmpty(filtroFinal))
            {
                vista.RowFilter = filtroFinal;
            }
            else
            {
                // Si no hay filtros, mostrar todos los datos.
                vista.RowFilter = string.Empty;
            }

            dgvEmpresas.DataSource = vista;

            if (vista.Count == 0 && (!string.IsNullOrEmpty(filtroFinal)))
            {
                MessageBox.Show("No se encontraron resultados con los filtros aplicados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmpresas.DataSource = tablaEmpresas;
            }
        }

        
        //TODO: Metodo que maneja el evento KeyPress para permitir solo números en el txtBuscarID.
        
        private void txtBuscarID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos y la tecla de Backspace (para borrar).
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si la tecla no es un número ni una tecla de control, se cancela la entrada.
                e.Handled = true;
            }
        }

        //TODO: metodo del evento KeyPress para permitir solo números en txtBuscarDNI si se elige la opción "ID"
        private void txtBuscarDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtener la opción seleccionada en el ComboBox
            string filtroSeleccionado = cmbNuevo.SelectedItem?.ToString();

            // Solo aplicar el filtro si la opción es "ID"
            if (filtroSeleccionado == "ID")
            {
                // Solo permite dígitos y la tecla de Backspace (para borrar).
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            } 
        }

        //TODO: Eventos
        //TODO: Evento click del boton Asiganr
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (_enAsignacion) return;     // evita doble disparo / doble click
            _enAsignacion = true;
            btnAsignar.Enabled = false;
            UseWaitCursor = true;          // feedback visual (opcional)

            try
            {
                // 1) Leer IDs desde los TextBox si están escritos
                if (!string.IsNullOrWhiteSpace(txboxIdPersona.Text) &&
                    int.TryParse(txboxIdPersona.Text, out var personaIdManual))
                {
                    idPostulanteSeleccionado = personaIdManual;
                }

                if (!string.IsNullOrWhiteSpace(texboxIdOferta.Text) &&
                    int.TryParse(texboxIdOferta.Text, out var ofertaIdManual))
                {
                    idOfertaSeleccionada = ofertaIdManual;
                }

                // 2) Validaciones
                if (idPostulanteSeleccionado <= 0)
                {
                    MessageBox.Show("Por favor, selecciona un postulante o escribe un ID válido en 'txboxIdPersona'.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (idOfertaSeleccionada <= 0)
                {
                    MessageBox.Show("Por favor, selecciona una oferta o escribe un ID válido en 'texboxIdOferta'.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3) Ejecutar asignación (no cambia Ocupada)
                var asignacionServicio = new AsignacionServicio();
                asignacionServicio.AsignarOfertaAPersona(idPostulanteSeleccionado, idOfertaSeleccionada);

                // 4) Confirmación (puedes refrescar si quieres; ya no la marcará Ocupada)
                MessageBox.Show(
                    $"Asignación OK.\nPersonaId: {idPostulanteSeleccionado}\nOfertaId: {idOfertaSeleccionada}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: recargar la grilla (seguirá mostrando la oferta)
                CargarOfertas();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo asignar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                var msg = ex is Microsoft.Data.SqlClient.SqlException sqlEx
                    ? $"{ex.Message}\n(SQL #{sqlEx.Number})"
                    : ex.Message;

                MessageBox.Show($"Ocurrió un error al asignar: {msg}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
                btnAsignar.Enabled = true;
                _enAsignacion = false;
            }
        }
        //TODO: Aplicacion en el evento click del boton para filtrar las ofertas
        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            AplicarFiltrosEmpresas();
        }

        private void cmbFiltroArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosEmpresas();
        }

        // Maneja el clic del botón para filtrar postulantes
        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            // Llama a la función de filtrado con el texto del TextBox.
            FiltrarPostulantes(txtBuscarDNI.Text.Trim());
        }


        //TODO: Metodo que aneja el evento CellClick para dgvPostulantes, confirma la selección y guarda el ID.

        private void dgvPostulantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPostulantes.Rows[e.RowIndex];

            // Intenta leer el ID por nombre de columna; si no, prueba conversión
            if (row.Cells["Id"]?.Value is int id)
                idPostulanteSeleccionado = id;
            else
                int.TryParse(row.Cells["Id"]?.Value?.ToString(), out idPostulanteSeleccionado);

            // Refleja en el TextBox
            txboxIdPersona.Text = idPostulanteSeleccionado > 0 ? idPostulanteSeleccionado.ToString() : string.Empty;

            var nombrePostulante = row.Cells["Nombre"]?.Value?.ToString() ?? string.Empty;

            if (idPostulanteSeleccionado > 0)
                MessageBox.Show($"Postulante seleccionado: {nombrePostulante} (ID: {idPostulanteSeleccionado})",
                    "Selección Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo leer el Id del postulante de la fila seleccionada.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //TODO: Metodo que maneja el evento CellClick para dgvEmpresas, confirma la selección y guarda el ID.

        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvEmpresas.Rows[e.RowIndex];

            if (row.Cells["IdOferta"]?.Value is int id)
                idOfertaSeleccionada = id;
            else
                int.TryParse(row.Cells["IdOferta"]?.Value?.ToString(), out idOfertaSeleccionada);

            texboxIdOferta.Text = idOfertaSeleccionada > 0 ? idOfertaSeleccionada.ToString() : string.Empty;

            var nombrePuesto = row.Cells["NombrePuesto"]?.Value?.ToString() ?? string.Empty;

            if (idOfertaSeleccionada > 0)
                MessageBox.Show($"Oferta seleccionada: {nombrePuesto} (ID: {idOfertaSeleccionada})",
                    "Selección Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo leer el Id de la oferta de la fila seleccionada.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cmbNuevo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBuscarDNI_TextChanged(object sender, EventArgs e) { }

        // Métodos vacíos para que no explote y no perderme 
        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvPostulantes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cmbFiltroBusqueda_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBuscarDNI_Click(object sender, EventArgs e) { }
        private void txtBuscarID_Click(object sender, EventArgs e) { }
        private void tabPage3_Click(object sender, EventArgs e) { }
        private void btnBuscar_Click(object sender, EventArgs e) { }

        // Lógica de navegación
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

        private bool _enAsignacion = false;

        //TODO: Metodo de personalizacion del datagridview Postulantes
        private void PersonalizarDataGridView()
        {
            // Cambiar el color de fondo general del DataGridView
            dgvPostulantes.BackgroundColor = Color.FromArgb(240, 248, 255); // Azul muy suave, estilo "Azure"

            // Personalizar el color de los encabezados de las columnas
            dgvPostulantes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul oscuro
            dgvPostulantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPostulantes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvPostulantes.ColumnHeadersHeight = 40;

            // Cambiar el color de las filas
            dgvPostulantes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvPostulantes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255); // Azul suave en filas alternas
            dgvPostulantes.RowsDefaultCellStyle.ForeColor = Color.Black;

            // Cambiar el color del borde del DataGridView
            dgvPostulantes.BorderStyle = BorderStyle.FixedSingle;
            dgvPostulantes.GridColor = Color.FromArgb(200, 200, 200); // Gris claro para las líneas de la cuadrícula

            // Personalizar las celdas
            dgvPostulantes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul oscuro cuando se selecciona
            dgvPostulantes.DefaultCellStyle.SelectionForeColor = Color.White; // Texto blanco cuando se selecciona

            // Personalizar las celdas al pasar el ratón (Hover)
            dgvPostulantes.CellMouseEnter += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    dgvPostulantes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(173, 216, 230); // Azul claro cuando el mouse pasa
                }
            };

            dgvPostulantes.CellMouseLeave += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    dgvPostulantes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; // Vuelve a blanco
                }
            };

            // Personalizar la fuente de las celdas
            dgvPostulantes.DefaultCellStyle.Font = new Font("Arial", 9);

            // Personalizar las filas de la cabecera al ser seleccionadas
            dgvPostulantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPostulantes.MultiSelect = false;

            // Ajustar el tamaño de las columnas automáticamente según el contenido
            dgvPostulantes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        //TODO: Metodo de personalizacion del datagridview de empresa
        private void PersonalizarDataGridView2()
        {
            // Cambiar el color de fondo general del DataGridView
            dgvEmpresas.BackgroundColor = Color.FromArgb(240, 248, 255); // Azul muy suave, estilo "Azure"

            // Personalizar el color de los encabezados de las columnas
            dgvEmpresas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul oscuro
            dgvEmpresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmpresas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvEmpresas.ColumnHeadersHeight = 40;

            // Cambiar el color de las filas
            dgvEmpresas.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEmpresas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255); // Azul suave en filas alternas
            dgvEmpresas.RowsDefaultCellStyle.ForeColor = Color.Black;

            // Cambiar el color del borde del DataGridView
            dgvEmpresas.BorderStyle = BorderStyle.FixedSingle;
            dgvEmpresas.GridColor = Color.FromArgb(200, 200, 200); // Gris claro para las líneas de la cuadrícula

            // Personalizar las celdas
            dgvEmpresas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul oscuro cuando se selecciona
            dgvEmpresas.DefaultCellStyle.SelectionForeColor = Color.White; // Texto blanco cuando se selecciona

            // Personalizar las celdas al pasar el ratón (Hover)
            dgvEmpresas.CellMouseEnter += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    dgvEmpresas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(173, 216, 230); // Azul claro cuando el mouse pasa
                }
            };

            dgvEmpresas.CellMouseLeave += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    dgvEmpresas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; // Vuelve a blanco
                }
            };

            // Personalizar la fuente de las celdas
            dgvEmpresas.DefaultCellStyle.Font = new Font("Arial", 9);

            // Personalizar las filas de la cabecera al ser seleccionadas
            dgvEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpresas.MultiSelect = false;

            // Ajustar el tamaño de las columnas automáticamente según el contenido
            dgvEmpresas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        //TODO: Metodo que ajusta los margenes
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

                // Posición del form en pantalla
                var p = this.PointToScreen(Point.Empty);

                // AFUERA, pegado al borde derecho y centrado vertical
                int x = p.X + this.Width;
                int y = p.Y + (this.Height - _formBoton.Height) / 2;

                // Mantener visible en el mismo monitor (evita que se “corte”)
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
