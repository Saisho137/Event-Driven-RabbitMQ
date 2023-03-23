using System.Data.SqlClient;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using SpotifySubscriber1;

SqlConnection conexion = new SqlConnection(@"Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=FotoMultas;Data Source=SANTIAGOPC\SQLEXPRESS");

var factory = new ConnectionFactory
{
    HostName = "fly.rmq.cloudamqp.com",
    UserName = "vfykuqrh",
    VirtualHost = "vfykuqrh",
    Password = "VaI1zoIra_KSk3OPYolCiA0EQh7FOmpL"
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{


    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    var obj = JsonConvert.DeserializeObject<ModelObject>(message);

    Console.WriteLine($" [x] Received {message}");

    conexion.Open();

    //Estructura del query
    string insert = string.Format(
        "INSERT INTO historial VALUES ('{0}','{1}','{2}')",
        obj.placa, obj.codigoInfraccion, obj.momentoInfraccion);

    Console.WriteLine(obj.placa.ToString() + " + " + obj.codigoInfraccion + " + " + obj.momentoInfraccion );

    //Ejecutar el insert con la conexion
    SqlCommand comando = new SqlCommand(insert, conexion);

    comando.ExecuteNonQuery();//escritura
    conexion.Close();
};

channel.BasicConsume(queue: "TransitoEnvigado",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

