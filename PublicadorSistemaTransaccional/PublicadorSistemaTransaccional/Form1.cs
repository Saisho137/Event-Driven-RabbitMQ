using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace PublicadorSistemaTransaccional
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, EventArgs e)
        {
            try {
                Publicador publicador = new Publicador();
                Model model = new Model();
                //
                model.inscripcion = "Inscripcion";
                model.cuentaOrigen = int.Parse(tbCuentaOrigen.Text);
                model.cuentaInscrita = int.Parse(tbCuentaInscrita.Text);
                model.cedulaTitular = int.Parse(tbCedula.Text);
                model.fechaInscripcion = DateTime.Now.ToString("yyyy/MM/dd");
                //
                publicador.Publisher(model);
                //
                MessageBox.Show("El Json se ha publicado con exito", 
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //
                tbCedula.Text = "";
                tbCuentaInscrita.Text = "";
                tbCuentaOrigen.Text = "";
            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
    }
}