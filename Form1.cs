using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Control_Ventas_Tecnologi
{
    public partial class Form1 : Form
    {

        // Variables para manejar el estado de la aplicación desde global, como el empleado logueado y la lista de productos

        private Empleados _empleadoLogueado; // Variable para almacenar el empleado logueado
        private List<Productos> _listaProductos; // Variable para almacenar la lista de productos
        private ProductosBaseDatos productosBase = new ProductosBaseDatos(); // Instancia de la clase para acceder a los productos
        private string _codigoAEliminar; //| Variable para almacenar el código del producto a eliminar
        private decimal totalFactura = 0; // Para acumular el total de la venta actual
        private ContextMenuStrip menuEntregas; // Menú para cambiar estado de entrega
        private CheckBox chkEntregado; // CheckBox para marcar entrega inmediata
        private Label lblClienteFactura; // Label para mostrar nombre cliente en factura
        private Label lblTotalFacturaFinal; // Label para mostrar total en factura final

        public Form1()
        {
            InitializeComponent();
            ConfigurarVenta();
            ConfigurarMenuEntregas();
            ConfigurarControlesExtra();
        }

        private void ConfigurarControlesExtra()
        {
            // Checkbox en Cajero: Reubicado para mayor visibilidad al lado de los datos de venta
            chkEntregado = new CheckBox();
            chkEntregado.Text = "Entrega Inmediata";
            chkEntregado.AutoSize = true;
            chkEntregado.Location = new Point(408, 160); // Cerca del selector de fecha
            chkEntregado.Font = new Font("Arial", 10, FontStyle.Bold);
            Cajero.Controls.Add(chkEntregado);
            chkEntregado.BringToFront();

            // Label Cliente en Factura (Compras): Reubicado y tamaño de fuente ajustado para evitar que quede oculto
            lblClienteFactura = new Label();
            lblClienteFactura.AutoSize = true;
            lblClienteFactura.Location = new Point(30, 80); // Subido para dar espacio
            lblClienteFactura.Font = new Font("Arial", 11, FontStyle.Bold);
            Compras.Controls.Add(lblClienteFactura);
            lblClienteFactura.BringToFront();

            // Label Total en Factura (Compras): Reubicado y tamaño de fuente ajustado
            lblTotalFacturaFinal = new Label();
            lblTotalFacturaFinal.AutoSize = true;
            lblTotalFacturaFinal.Location = new Point(30, 120);
            lblTotalFacturaFinal.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTotalFacturaFinal.ForeColor = Color.DarkBlue;
            Compras.Controls.Add(lblTotalFacturaFinal);
            lblTotalFacturaFinal.BringToFront();

            // Ajuste estético de etiquetas de producto para que aparezcan "al lado" o de forma más integrada
            lblNombreProd.Location = new Point(408, 250); // Justo debajo del combo de código
            lblPrecio.Location = new Point(650, 215);    // Al lado del combo de código
            lblPrecio.Font = new Font("Arial", 10, FontStyle.Bold);
            lblPrecio.ForeColor = Color.DarkRed;

            // Configurar el DateTimePicker para que solo muestre fecha corta
            dateTimePickerFecha.Format = DateTimePickerFormat.Short;
            
            // Mover No. Factura a una esquina
            lblNoFactura.Location = new Point(20, 20);
            lblNoFactura.Font = new Font("Arial", 10, FontStyle.Italic);
        }

        private void ConfigurarMenuEntregas()
        {
            menuEntregas = new ContextMenuStrip();
            ToolStripMenuItem itemEntregado = new ToolStripMenuItem("Marcar como ENTREGA CONFIRMADA");
            ToolStripMenuItem itemPendiente = new ToolStripMenuItem("Marcar como PENDIENTE");

            itemEntregado.Click += (s, e) => CambiarEstadoEntrega(true);
            itemPendiente.Click += (s, e) => CambiarEstadoEntrega(false);

            menuEntregas.Items.Add(itemEntregado);
            menuEntregas.Items.Add(itemPendiente);
            dataGridViewPendientes.ContextMenuStrip = menuEntregas;
        }

        private void CambiarEstadoEntrega(bool entregado)
        {
            if (dataGridViewPendientes.CurrentRow == null) return;

            string noFactura = dataGridViewPendientes.CurrentRow.Cells["Factura"].Value.ToString();
            BaseDatosFactura dbFact = new BaseDatosFactura();
            List<Factura> todas = dbFact.LeerFacturas();

            var fact = todas.FirstOrDefault(f => f.NoFactura == noFactura);
            if (fact != null)
            {
                fact.Entregado = entregado;
                dbFact.GuardarTodo(todas);
                MessageBox.Show("Estado actualizado correctamente");
                CargarGridPendientes();
            }
        }

        // Este método se encarga de cargar los productos en los DataGridView cada vez que se hace un cambio (agregar, editar, eliminar)
        private void CargaGridProductos1()
        {
            _listaProductos = productosBase.LeerProductos();
            // Decimos que la fuente de datos es "nada" para que se limpie
            dataGridViewProductos.DataSource = null;

            // Le volvemos a pasar la lista (que ya tiene los cambios de agregar/editar)
            dataGridViewProductos.DataSource = _listaProductos;
            dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductos.ClearSelection(); // Esto es para que no aparezca seleccionado el primer producto al cargar el grid, se ve más limpio así

            dataGridViewEdicion.DataSource = null;
            dataGridViewEdicion.DataSource = _listaProductos;
            dataGridViewEdicion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEdicion.ReadOnly = false; // Permite la edición directa en el DataGridView
            dataGridViewEdicion.ClearSelection();

            dataGridViewCarrito.DataSource = null;


        }


        //Sirve para limpiar
        private void LimpiarEntradas()
        {
            // Esto busca en todo el formulario
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                // Si tus TextBox están dentro de un TabControl o Panel,
                // debes buscar dentro de ese contenedor:
                foreach (Control subControl in tabControl1.SelectedTab.Controls)
                {
                    if (subControl is TextBox) { ((TextBox)subControl).Clear(); }
                }
            }
        }


        // Este método verifica si hay algún TextBox vacío en el formulario y muestra un mensaje si es así.
        private bool DetectarTextoVacio()
        {
            bool camponoValido = tabControl1.SelectedTab.Controls
        .OfType<TextBox>()
        .Any(t => string.IsNullOrWhiteSpace(t.Text));

            if (camponoValido)
            {
                MessageBox.Show("Aún faltan campos por completar.");
                return true;
            }
            return false;
        }


        private void buttonGerente_Click(object sender, EventArgs e)
        {

            panelUser1.Visible = true;
        }

        private void buttonRegresar1_Click(object sender, EventArgs e)
        {
            panelUser1.Visible = false;
            textUser.Clear();

        }


        // Este método se encarga de verificar el usuario ingresado, compararlo con la lista de empleados y mostrar el panel de contraseña si el usuario es correcto
        private void buttonAvanzar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textUser.Text)) // Verifica si el campo de usuario está vacío o contiene solo espacios en blanco
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario.");
                return;
            }



            baseDatosEmpleados baseDatos = new baseDatosEmpleados(); //llama a la clase
            List<Empleados> bsEmpleados = baseDatos.LeerEmpleados(); //lee la lista de empleados del json




            _empleadoLogueado = bsEmpleados.FirstOrDefault(emp => emp.user == textUser.Text); //Compara la lista Json con el dato ingresado en el Texbox, si encuentra una coincidencia, asigna el empleado a la variable _empleadoLogueado

            if (_empleadoLogueado != null)

            {

                panelContra1.Visible = true;
                MessageBox.Show("Usuario correcto, ingrese su contraseña");
                panelUser1.Visible = false; // Oculta el panel de usuario después de un inicio de sesión exitoso
                textUser.Clear();

            }
            else
            {


                MessageBox.Show("Usuario incorrecto, intente de nuevo");

                _empleadoLogueado = null; // Limpia el empleado logueado en caso de error


                textUser.Clear(); // Limpia el campo de usuario en caso de error

            }
        }

        private void buttonRegresar2_Click(object sender, EventArgs e)
        {
            panelContra1.Visible = false;
            panelUser1.Visible = true;
            textBoxContra.Clear(); // ← agregar esto
        }



        // Este método se encarga de verificar la contraseña ingresada, compararla con la del empleado logueado y mostrar la pestaña correspondiente según el rol del empleado
        private void buttonSiguiente2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxContra.Text))
            {
                MessageBox.Show("Por favor, ingrese su contraseña.");
                return;
            }

            if (_empleadoLogueado != null && textBoxContra.Text == _empleadoLogueado.password) // Verifica que el empleado logueado no sea nulo y que la contraseña ingresada coincida con la del empleado 
            {
                if (_empleadoLogueado.rol == "Gerente")
                {

                    tabControl1.SelectedTab = Gerente; // Cambia a la pestaña "Gerente" si la contraseña es correcta
                    textBoxContra.Clear();
                }


                else if (_empleadoLogueado.rol == "Cajero")
                {

                    using (Form2 f2 = new Form2()) // Usamos 'using' para asegurar limpieza
                    {
                        this.Hide();
                        if (f2.ShowDialog() == DialogResult.OK)
                        {
                            this.Show();

                            // LEEMOS LO QUE PASÓ EN EL FORM2
                            if (f2.AccionARealizar == "REGISTRAR")
                            {

                                tabControl1.SelectedTab = Clientes;
                                textBoxNits.Text = f2.NitSeleccionado; // Pasamos el NIT seleccionado al TextBox de registro de clientes para no escribirlo denuevo

                            }
                            else if (f2.AccionARealizar == "VENDER")
                            {
                                DatosCliente clienteSeleccionado = new BaseDatosClienteas().Leer().FirstOrDefault(c => c.nit == f2.NitSeleccionado); // Buscamos el cliente seleccionado en el Form2 para obtener su nombre completo y mostrarlo en la pestaña de compras, además del NIT que ya tenemos
                                // Ir a la pestaña de compras directamente
                                tabControl1.SelectedTab = Cajero;
                                lblnitCompra.Text = f2.NitSeleccionado;
                                lblnombre.Text = clienteSeleccionado?.nombre + " " + clienteSeleccionado?.apellido; // Usamos el operador null-conditional para evitar errores en caso de que no se encuentre el cliente, aunque debería encontrarse siempre porque el Form2 solo muestra clientes existentes
                            }
                        }

                    }
                }


            }
            else
            {
                MessageBox.Show("Contraseña incorrecta, intente de nuevo");
                textBoxContra.Clear(); // Limpia el campo de contraseña en caso de error

            }

        }


        private void buttonCajero_Click(object sender, EventArgs e)
        {
            panelUser1.Visible = true;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la aplicación
        }

        private void buttonlistadoProductos_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = ListaProducto;
            ActualizarDatosProducto();

        }

        private void buttonMostrar3_Click(object sender, EventArgs e)
        {
            ActualizarDatosProducto();
            labelEstado.Text = "Datos actualizados";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSalir3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Gerente;
        }

        private void buttonRegresar3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Inicio;
        }

        private void buttonSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonatras_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Gerente;
        }


        // Este método se encarga de crear un nuevo producto a partir de los datos ingresados en los TextBox, guardarlo en el JSON, mostrar un mensaje de confirmación y actualizar la lista de productos para que se refleje el cambio en el programa
        private void buttonNuevos_Click(object sender, EventArgs e)
        {
            if (DetectarTextoVacio())
            {
                return; // Detiene la ejecución del método si hay un TextBox vacío
            }
            Productos produc = new Productos
            {
                Codigo = textBoxCodigo.Text,
                Nombre = textBoxNombre.Text,
                Marca = textBoxMarca.Text,
                PrecioCompra = textBoxPrecioCompra.Text,
                PrecioVenta = textBoxPrecioVenta.Text,
                Existencia = int.Parse(textBoxCantidad.Text)


            };
            LimpiarEntradas(); // Limpia los TextBox después de crear el producto
            productosBase.GuardarProductos(produc);

            _listaProductos = productosBase.LeerProductos();

            MessageBox.Show("Producto agregado correctamente");


        }


        private void button1_Click(object sender, EventArgs e) //Ya muestra automaticamente los datos en los grid
        {
            tabControl1.SelectedTab = Modificar;
            ActualizarDatosProducto();



        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            panelConfirmacion.Visible = true;


        }

        private void buttonCargar_Click(object sender, EventArgs e) //Solo para tener un reset y mostrar el mensaje
        {
            ActualizarDatosProducto();
            labelEstado.Text = "Datos actualizados";
        }

        public void ActualizarDatosProducto() //Metodo para actualizar los datos del DataGridView, lo llamo cada vez que hago un cambio en el json para que se refleje en el programa
        {
            _listaProductos = productosBase.LeerProductos();
            CargaGridProductos1();
        }

        private void buttonAgrega_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = nuevosProdutos;

        }



        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonno_Click(object sender, EventArgs e)
        {
            panelConfirmacion.Visible = false;
            tabControl1.SelectedTab = Modificar;

        }

        // Este método se encarga de validar que no haya celdas vacías en el DataGridView de edición, crear una nueva lista de productos a partir de los datos editados, guardarla en el JSON, mostrar un mensaje de confirmación y actualizar la lista de productos para que se refleje el cambio en el programa
        private void buttonsi_Click(object sender, EventArgs e)
        {

            // Validar celdas vacías en el grid de EDICIÓN
            foreach (DataGridViewRow fila in dataGridViewEdicion.Rows) // ← cambiar aquí
            {
                if (fila.IsNewRow) continue;

                foreach (DataGridViewCell celda in fila.Cells)
                {
                    if (celda.Value == null || string.IsNullOrWhiteSpace(celda.Value.ToString()))
                    {
                        MessageBox.Show("Error en la actualización de datos, revise haber rellenado las columnas");
                        return;
                    }
                }
            }

            List<Productos> listaEditada = new List<Productos>();

            foreach (DataGridViewRow fila in dataGridViewEdicion.Rows) // ← cambiar aquí también
            {
                if (fila.IsNewRow) continue;

                listaEditada.Add(new Productos
                {
                    Codigo = fila.Cells["Codigo"].Value.ToString(),
                    Nombre = fila.Cells["Nombre"].Value.ToString(),
                    Marca = fila.Cells["Marca"].Value.ToString(),
                    PrecioCompra = fila.Cells["PrecioCompra"].Value.ToString(),
                    PrecioVenta = fila.Cells["PrecioVenta"].Value.ToString(),
                    Existencia = fila.Cells["Existencia"].Value != null ? int.Parse(fila.Cells["Existencia"].Value.ToString()) : 0 // Maneja el caso de celdas vacías para Existencia, asignando 0 si es nulo o vacío
                });
            }

            productosBase.GuardarTodo(listaEditada);
            MessageBox.Show("Cambios guardados correctamente");
            panelConfirmacion.Visible = false;

        }

        // Este método se encarga de mostrar el panel de confirmación para eliminar un producto, almacenando el código del producto seleccionado para eliminarlo posteriormente si el usuario confirma la acción
        private void buttonEliminarColum_Click(object sender, EventArgs e)
        {
            if (dataGridViewEdicion.CurrentRow == null)

            {
                MessageBox.Show("Selecciona un producto primero");
                return;

            }
            _codigoAEliminar = dataGridViewEdicion.CurrentRow.Cells["Codigo"].Value.ToString();

            panelConfirmate.Visible = true;

            panelConfirmate.BringToFront(); // Asegura que el panel de confirmación esté al frente para que el usuario lo vea claramente
        }

        private void buttonnot_Click(object sender, EventArgs e)
        {
            panelConfirmate.Visible = false;
        }


        // Este método se encarga de eliminar el producto seleccionado, actualizar el grid y mostrar un mensaje de confirmación
        private void buttonyes_Click(object sender, EventArgs e)
        {

            productosBase.EliminarProducto(_codigoAEliminar);
            CargaGridProductos1();
            MessageBox.Show("Producto eliminado correctamente");

            panelConfirmate.Visible = false;
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Gerente;
        }


        // Este método se encarga de registrar un nuevo cliente, guardarlo en el JSON, mostrar un mensaje de confirmación y pasar los datos del cliente a la pestaña de compras
        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if (DetectarTextoVacio())
            {
                return;
            }

            DatosCliente newCliente = new DatosCliente
            {
                nit = textBoxNits.Text,
                nombre = textBoxnameNew.Text,
                apellido = textBoxApellido.Text,
                direcion = textBoxDireccion.Text,
                telefono = textBoxNoTelefono.Text,
            };

            LimpiarEntradas();

            BaseDatosClienteas dbCliente = new BaseDatosClienteas();
            dbCliente.Guardar(newCliente);

            MessageBox.Show("Cliente registrado correctamente");

            lblnitCompra.Text = newCliente.nit;
            lblnombre.Text = newCliente.nombre + " " + newCliente.apellido;
            lblnitaCajero.Text = newCliente.nit;
            lblnombreaCajero.Text = newCliente.nombre + " " + newCliente.apellido;



            tabControl1.SelectedTab = Cajero;


        }

        private void buttonReturn2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Show();
        }

        private void buttonIrFactura_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = Compras;
            LimpiarEntradas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Show();
        }

        // Este método se encarga de configurar el ComboBox para que muestre los códigos de los productos con autocompletado, facilitando la selección del producto al momento de realizar una venta       
        public void ConfigurarVenta()
        {
            _listaProductos = productosBase.LeerProductos();

            // 1. Configuramos el comportamiento ANTES de los datos
            comboBoxCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCodigo.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCodigo.DropDownStyle = ComboBoxStyle.DropDown; // IMPORTANTE: No usar DropDownList

            // 2. Entregamos los datos
            comboBoxCodigo.DataSource = null;
            comboBoxCodigo.DataSource = _listaProductos;

            // 3. Establecemos qué propiedad de tu JSON debe mostrar
            comboBoxCodigo.DisplayMember = "Codigo";
            comboBoxCodigo.ValueMember = "Codigo";
            comboBoxCodigo.SelectedIndex = -1;
            comboBoxCodigo.Text = string.Empty;

            // 4. Agregamos evento de cambio de texto para asegurar activación de controles incluso sin selección por click
            comboBoxCodigo.TextChanged += (s, e) => ComboBoxCodigo_TextChanged(s, e);

        }

        // Se dispara al escribir en el combo, ayuda a desbloquear cantidad si el código es válido
        private void ComboBoxCodigo_TextChanged(object sender, EventArgs e)
        {
            var p = _listaProductos.FirstOrDefault(x => x.Codigo == comboBoxCodigo.Text);
            if (p != null)
            {
                ActualizarEstadoControles(p);
            }
        }


        // Este método se encarga de actualizar los labels de información del producto seleccionado en el ComboBox, así como de habilitar o deshabilitar el control de cantidad y el botón de añadir al carrito según la disponibilidad del producto
        private void comboBoxCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCodigo.SelectedIndex == -1 || comboBoxCodigo.SelectedItem == null)
            {
                // Si no hay nada seleccionado, verificamos si el texto coincide con algo (por si fue escrito)
                var pTexto = _listaProductos.FirstOrDefault(x => x.Codigo == comboBoxCodigo.Text);
                if (pTexto != null)
                {
                    ActualizarEstadoControles(pTexto);
                    return;
                }

                lblNombreProd.Text = "Producto: -";
                lblPrecio.Text = "Precio: Q 0.00";
                lblDisponible.Text = "Estado: Seleccione producto";
                numCantidad.Enabled = false;
                return;
            }

            if (comboBoxCodigo.SelectedItem is Productos p)
            {
                lblNombreProd.Text = "Producto: " + p.Nombre;
                lblPrecio.Text = "Precio: Q " + p.PrecioVenta;

                // Actualizamos también label24 por si se usa de respaldo
                label24.Text = "Marca: " + p.Marca;

                // Llamamos a la lógica de bloqueo/activación
                ActualizarEstadoControles(p);
            }
        }


        // Este método se encarga de añadir el producto seleccionado al carrito de compras, calculando el subtotal, actualizando el total a pagar, restando la cantidad seleccionada del stock en la RAM para mostrarlo en el label y limpiando los controles para la siguiente selección
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBoxCodigo.SelectedItem is Productos p || (_listaProductos.FirstOrDefault(x => x.Codigo == comboBoxCodigo.Text) is Productos p2 && (p = p2) != null))
            {
                int cantElegida = (int)numCantidad.Value;
                if (cantElegida <= 0) return;

                decimal precio = decimal.Parse(p.PrecioVenta);
                decimal subtotal = precio * cantElegida;

                // ESTA LÍNEA ES LA QUE DIBUJA LA FILA
                // El orden debe ser: Codigo, Nombre, Marca, Cantidad, Precio, Subtotal
                dataGridViewCarrito.Rows.Add(p.Codigo, p.Nombre, p.Marca, cantElegida, precio, subtotal);

                // Actualizar el total que el cliente ve
                totalFactura += subtotal;
                lblTotalPagar.Text = "Q " + totalFactura.ToString("N2");

                // Restar stock en la RAM para el label
                p.Existencia -= cantElegida;
                ActualizarEstadoControles(p);

                // Limpiar para el siguiente
                comboBoxCodigo.SelectedIndex = -1;
                numCantidad.Value = 0;
                comboBoxCodigo.Focus();
            }
        }

        private void buttonGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCarrito.Rows.Count == 0)
                {
                    MessageBox.Show("El carrito está vacío.");
                    return;
                }

                Factura nuevaVenta = new Factura
                {
                    Nit2 = lblnitCompra.Text,
                    NombreCliente = lblnombre.Text,
                    FechaVenta = dateTimePickerFecha.Value,
                    TotalPagado = totalFactura,
                    Entregado = chkEntregado.Checked // Captura el estado del checkbox
                };

                foreach (DataGridViewRow fila in dataGridViewCarrito.Rows)
                {
                    if (fila.IsNewRow) continue;

                    string cod = fila.Cells["Codigo"].Value.ToString();
                    int cant = int.Parse(fila.Cells["Cantidad"].Value.ToString());

                    nuevaVenta.Items.Add(new DetalleVenta
                    {
                        Codigo = cod,
                        Nombre = fila.Cells["Nombre"].Value.ToString(),
                        Cantidad = cant,
                        PrecioUnitario = decimal.Parse(fila.Cells["Precio"].Value.ToString()),
                        Subtotal = decimal.Parse(fila.Cells["Subtotal"].Value.ToString())
                    });

                    var prodStock = _listaProductos.FirstOrDefault(x => x.Codigo == cod);
                    if (prodStock != null) prodStock.Existencia -= cant;
                }

                BaseDatosFactura dbFact = new BaseDatosFactura();
                dbFact.GuardarFactura(nuevaVenta);

                // Actualizamos labels de la pestaña FACTURA (Compras)
                lblNoFactura.Text = "No. Factura: " + nuevaVenta.NoFactura;
                lblClienteFactura.Text = "Cliente: " + nuevaVenta.NombreCliente;
                lblTotalFacturaFinal.Text = "TOTAL PAGADO: Q " + totalFactura.ToString("N2");

                productosBase.GuardarTodo(_listaProductos);

                MessageBox.Show("Venta realizada con éxito e inventario actualizado");

                // Actualización inmediata de reportes para el Gerente
                CargarGridMasVendidos();
                CargarGridPendientes();
                CargarGridVentasPorFecha(dtpInicio.Value, dtpFin.Value);
                CargarGridGanancias(dtpInicio.Value, dtpFin.Value);

                // NO LIMPIAMOS EL CARRITO AQUÍ para que el usuario pueda ver la factura generada en la pestaña Compras
                // La limpieza se hará al regresar (buttonFIn_Click)
                chkEntregado.Checked = false;
                ActualizarDatosProducto();

                // Ir a la pestaña de factura final
                tabControl1.SelectedTab = Compras;
            }
            catch (Exception ex) { MessageBox.Show("Error al generar factura: " + ex.Message); }
        }

        // Este botón sirve para regresar de la vista de factura final al cajero
        private void buttonFIn_Click(object sender, EventArgs e)
        {
            // Limpiamos los datos de la venta anterior al regresar
            totalFactura = 0;
            lblTotalPagar.Text = "Q 0.00";
            dataGridViewCarrito.Rows.Clear();
            
            tabControl1.SelectedTab = Cajero;
        }



        // Este método se encarga de actualizar el estado de los controles relacionados con la selección del producto, como el label de disponibilidad, el control de cantidad y el botón de añadir al carrito, dependiendo de la existencia del producto seleccionado
        private void ActualizarEstadoControles(Productos p)
        {
            if (p == null) return;

            if (p.Existencia <= 0)
            {
                lblDisponible.Text = "PRODUCTO AGOTADO";
                lblDisponible.ForeColor = Color.Red;

                numCantidad.Minimum = 0;
                numCantidad.Maximum = 0;
                numCantidad.Value = 0;
                numCantidad.Enabled = false;
                button1.Enabled = false; // Botón añadir al carrito
            }
            else
            {
                lblDisponible.Text = "Stock: " + p.Existencia;
                lblDisponible.ForeColor = Color.DarkGreen;

                numCantidad.Enabled = true;
                numCantidad.Minimum = 1; // Aseguramos que el mínimo sea 1 si hay stock
                numCantidad.Maximum = p.Existencia;
                
                // Solo reseteamos el valor si es necesario para evitar molestias al usuario
                if (numCantidad.Value < 1 || numCantidad.Value > p.Existencia)
                    numCantidad.Value = 1;

                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = ReportesFav;
            CargarGridMasVendidos();
        }

        private void buttondatosVentas_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = DatosVenta;
            CargarGridVentasPorFecha(dtpInicio.Value, dtpFin.Value);
        }

        private void CargarGridMasVendidos()
        {
            BaseDatosFactura dbFact = new BaseDatosFactura();
            List<Factura> todas = dbFact.LeerFacturas();

            if (todas == null || !todas.Any()) return;

            var ranking = todas
                .SelectMany(f => f.Items)
                .GroupBy(i => new { i.Codigo, i.Nombre })
                .Select(g => new {
                    Codigo = g.Key.Codigo,
                    Producto = g.Key.Nombre,
                    Vendidos = g.Sum(x => x.Cantidad)
                })
                .OrderByDescending(x => x.Vendidos)
                .ToList();

            dgvMasVendidos.DataSource = null;
            dgvMasVendidos.DataSource = ranking;
            dgvMasVendidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 2. TOTAL DE VENTAS ENTRE FECHAS
        private void CargarGridVentasPorFecha(DateTime inicio, DateTime fin)
        {
            BaseDatosFactura dbFact = new BaseDatosFactura();
            var todas = dbFact.LeerFacturas();

            if (todas == null) return;

            var ventas = todas
                .Where(f => f.FechaVenta.Date >= inicio.Date && f.FechaVenta.Date <= fin.Date)
                .Select(f => new {
                    Factura = f.NoFactura,
                    Cliente = f.NombreCliente,
                    Fecha = f.FechaVenta.ToShortDateString(),
                    Total = f.TotalPagado,
                    Estado = f.Entregado ? "ENTREGADO" : "PENDIENTE"
                }).ToList();

            dgvTotalVentas.DataSource = null;
            dgvTotalVentas.DataSource = ventas;
            dgvTotalVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lblTotalDineroVentas.Text = "Total Ventas: Q " + ventas.Sum(v => v.Total).ToString("N2");
        }

        // 3. GANANCIA (Aquí es donde suele fallar por los nulos)
        private void CargarGridGanancias(DateTime inicio, DateTime fin)
        {
            // SEGURIDAD: Si la lista global de productos está vacía, la cargamos
            if (_listaProductos == null || _listaProductos.Count == 0)
            {
                _listaProductos = productosBase.LeerProductos();
            }

            BaseDatosFactura dbFact = new BaseDatosFactura();
            var facturas = dbFact.LeerFacturas()
                .Where(f => f.FechaVenta.Date >= inicio.Date && f.FechaVenta.Date <= fin.Date).ToList();

            decimal gananciaTotal = 0;

            foreach (var f in facturas)
            {
                foreach (var item in f.Items)
                {
                    var pInv = _listaProductos.FirstOrDefault(p => p.Codigo == item.Codigo);
                    if (pInv != null)
                    {
                        // Convertimos el precio de compra asegurando que el formato decimal sea correcto
                        decimal costo = decimal.Parse(pInv.PrecioCompra);
                        gananciaTotal += (item.PrecioUnitario - costo) * item.Cantidad;
                    }
                }
            }

            lblResultadoGanancia.Text = "Ganancia Real: Q " + gananciaTotal.ToString("N2");
            lblResultadoGanancia.ForeColor = Color.Blue;
        }

        // 4. VENTAS PENDIENTES
        private void CargarGridPendientes()
        {
            BaseDatosFactura dbFact = new BaseDatosFactura();
            List<Factura> todas = dbFact.LeerFacturas();

            if (todas == null) return;

            // Mostramos todas pero marcamos el estado claramente
            var listaCompleta = todas
                .OrderByDescending(f => f.FechaVenta)
                .Select(f => new {
                    Factura = f.NoFactura,
                    Cliente = f.NombreCliente,
                    Fecha = f.FechaVenta.ToShortDateString(),
                    Monto = "Q " + f.TotalPagado.ToString("N2"),
                    Estado = f.Entregado ? "CONFIRMADA" : "PENDIENTE"
                }).ToList();

            dataGridViewPendientes.DataSource = null;
            dataGridViewPendientes.DataSource = listaCompleta;
            dataGridViewPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Pintar filas según estado
            foreach (DataGridViewRow row in dataGridViewPendientes.Rows)
            {
                if (row.Cells["Estado"].Value.ToString() == "PENDIENTE")
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void buttonGanancias_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = DatosGanancia;
            CargarGridGanancias(dtpInicio.Value, dtpFin.Value);
        }

        private void buttonOrden_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = DatosPendiente;
            CargarGridPendientes();
        }

        private void GenerarReporte_Click(object sender, EventArgs e)
        {
            // Fechas que solo usaremos para Ventas y Ganancias
            DateTime inicio = dtpInicio.Value;
            DateTime fin = dtpFin.Value;

            // 1. Reportes SIN filtro de fecha (Historial total)
            CargarGridMasVendidos();
            CargarGridPendientes();

            // 2. Reportes CON filtro de fecha (Rango específico)
            CargarGridVentasPorFecha(inicio, fin);
            CargarGridGanancias(inicio, fin);

            MessageBox.Show("Reportes actualizados: Ventas y Ganancias filtradas por fecha, el resto muestra totales.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Gerente;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Gerente;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Gerente;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Gerente;
        }
    }


}
