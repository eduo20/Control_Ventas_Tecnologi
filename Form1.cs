using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Control_Ventas_Tecnologi
{
    public partial class Form1 : Form
    {

        // No borren los private chavos, esos solo funcionan en el programa principal no los deje publicos para que no afecten en el resto del codigo negativamente
        // pd: todo esto lo investigue pq esta parte me generaba dudas ya que como estoy usando otra clase para la lectura y guardado de datos.

        private Empleados _empleadoLogueado; // Variable para almacenar el empleado logueado
        private List<Productos> _listaProductos; // Variable para almacenar la lista de productos
        private ProductosBaseDatos productosBase = new ProductosBaseDatos(); // Instancia de la clase para acceder a los productos
        public Form1()
        {
            InitializeComponent();


        }


        private void CargaGridProductos1()
        {
            _listaProductos = productosBase.LeerProductos();
            // Decimos que la fuente de datos es "nada" para que se limpie
            dataGridViewProductos.DataSource = null;

            // Le volvemos a pasar la lista (que ya tiene los cambios de agregar/editar)
            dataGridViewProductos.DataSource = _listaProductos;

            dataGridViewEdicion.DataSource = null;
            dataGridViewEdicion.DataSource = _listaProductos;
            dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
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
        private void buttonGerente_Click(object sender, EventArgs e)
        {

            panelUser1.Visible = true;
        }

        private void buttonRegresar1_Click(object sender, EventArgs e)
        {
            panelUser1.Visible = false;
        }

        private void buttonAvanzar1_Click(object sender, EventArgs e)
        {
            baseDatosEmpleados baseDatos = new baseDatosEmpleados(); //llama a la clase
            List<Empleados> bsEmpleados = baseDatos.LeerEmpleados(); //lee la lista de empleados del json

            _empleadoLogueado = bsEmpleados.FirstOrDefault(emp => emp.user == textUser.Text); //Compara la lista Json con el dato ingresado en el Texbox, si encuentra una coincidencia, asigna el empleado a la variable _empleadoLogueado

            if (_empleadoLogueado != null)

            {

                panelContra1.Visible = true;
                MessageBox.Show("Usuario correcto, ingrese su contraseña");
                panelUser1.Visible = false; // Oculta el panel de usuario después de un inicio de sesión exitoso
            }
            else
            {
                MessageBox.Show("Usuario incorrecto, intente de nuevo");
                _empleadoLogueado = null; // Limpia el empleado logueado en caso de error
                panelContra1.Visible = false;
                textUser.Clear(); // Limpia el campo de usuario en caso de error

            }
        }

        private void buttonRegresar2_Click(object sender, EventArgs e)
        {
            panelContra1.Visible = false;
            panelUser1.Visible = true;
            textBoxContra.Clear(); // ← agregar esto
        }

        private void buttonSiguiente2_Click(object sender, EventArgs e)
        {


            if (_empleadoLogueado != null && textBoxContra.Text == _empleadoLogueado.password) // Verifica que el empleado logueado no sea nulo y que la contraseña ingresada coincida con la del empleado
            {
                if (_empleadoLogueado.rol == "Gerente")
                    tabControl1.SelectedTab = Gerente; // Cambia a la pestaña "Gerente" si la contraseña es correcta


                else if (_empleadoLogueado.rol == "Cajero")
                {
                    tabControl1.SelectedTab = Cajero;
                }
                panelContra1.Visible = false; // Oculta el panel de contraseña después de un inicio de sesión exitoso

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

        private void buttonNuevos_Click(object sender, EventArgs e)
        {
            Productos produc = new Productos
            {
                Codigo = textBoxCodigo.Text,
                Nombre = textBoxNombre.Text,
                Marca = textBoxMarca.Text,
                PrecioCompra = textBoxPrecioCompra.Text,
                PrecioVenta = textBoxPrecioVenta.Text,
                Existencia = textBoxCantidad.Text

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
    }
}

