using System.Data.SqlClient;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using SuscriptorSistemaTransaccional;

SqlConnection conexion = new SqlConnection(@"Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=SistemaTransaccional;Data Source=SANTIAGOPC\SQLEXPRESS");

try
{
    var factory = new ConnectionFactory
    {
        HostName = "fly.rmq.cloudamqp.com",
        UserName = "cagoqerh",
        VirtualHost = "cagoqerh",
        Password = "A18e0PCaJSe9lm-0vlN91UuBK7p45Fj3"
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
            "INSERT INTO Historial_Inscripciones VALUES ('{0}','{1}','{2}','{3}','{4}')",
            obj.inscripcion, obj.cuentaOrigen, obj.cuentaInscrita, obj.cedulaTitular, obj.fechaInscripcion);
        //Ejecutar el insert con la conexion
        SqlCommand comando = new SqlCommand(insert, conexion);

        comando.ExecuteNonQuery();//escritura
        conexion.Close();
    };

    channel.BasicConsume(queue: "sistema.transaccional",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.ToString());
}
