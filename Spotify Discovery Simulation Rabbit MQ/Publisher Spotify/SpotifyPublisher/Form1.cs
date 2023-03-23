using RabbitMQ.Client;
using System.Text;
using System.Windows.Forms;

namespace SpotifyPublisher
{
    public partial class Form1 : Form
    {

        public void Publisher(string verified, string genre, string message) {
            var factory = new ConnectionFactory
            {
                HostName = "fly.rmq.cloudamqp.com",
                UserName = "lqxiljlu",
                VirtualHost = "lqxiljlu",
                Password = "x1PcYflgxWmmOQvVhnJpKiQc9PZT3VXE"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var routingKey = genre.ToLower() + "." + verified.ToLower();
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                        exchange: "discovery.spotify",
                        routingKey: routingKey,
                        body: body
                        );
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                Publisher(cbVerified.SelectedItem.ToString(), tbGenre.Text, tbMessage.Text);
                MessageBox.Show("Enviado con exito");
            }
            catch (Exception ex) {
                MessageBox.Show("Ingrese los datos correctamente");
            }
            
        }
    }
}