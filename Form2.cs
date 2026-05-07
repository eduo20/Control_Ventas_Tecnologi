using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Ventas_Tecnologi
{
    public partial class Form2 : Form
    {
        // Propiedades para almacenar el NIT seleccionado y la acción a realizar
        //Se preguntarans donde estan en el form1, y la respuesta es que se guardan en estas propiedades para que el Form1 las pueda leer después de cerrar el Form2
        public string NitSeleccionado { get; set; }  
        public string AccionARealizar { get; set; }

        public Form2()
        {
            InitializeComponent();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            string nitBusquetda = comboBoxnits.Text;
            BaseDatosClienteas baseDatos = new BaseDatosClienteas();

            List<DatosCliente> clientes = baseDatos.Leer();


            // Buscar el cliente por su NIT
            var clienteEncontrado = clientes.FirstOrDefault(c => c.nit == nitBusquetda);

            if (clienteEncontrado != null)
            {
                MessageBox.Show("Cliente encontrado: " + clienteEncontrado.nombre);

                // Aquí guardas el NIT en una variable para pasarlo al Form 1
                this.NitSeleccionado = clienteEncontrado.nit;
                this.AccionARealizar = "VENDER";

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("El NIT no existe. Debe registrar al cliente.");

                this.NitSeleccionado = nitBusquetda; // Mandamos el NIT para que no lo escriba otra vez
                this.AccionARealizar = "REGISTRAR";

                this.DialogResult = DialogResult.OK;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BaseDatosClienteas db = new BaseDatosClienteas();
            List<DatosCliente> lista = db.Leer();

            
            comboBoxnits.Items.Clear();

            
            foreach (var cliente in lista)
            {
                comboBoxnits.Items.Add(cliente.nit);
            }
        }
    }
}
