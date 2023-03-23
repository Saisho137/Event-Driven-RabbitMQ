using ApiPracticaTransito.Models;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace ApiPracticaTransito
{
    public class Class
    {
        public void Publisher(responseInfraccion result)
        {
            var factory = new ConnectionFactory
            {
                HostName = "fly.rmq.cloudamqp.com",
                UserName = "vfykuqrh",
                VirtualHost = "vfykuqrh",
                Password = "VaI1zoIra_KSk3OPYolCiA0EQh7FOmpL"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var messageJson = JsonConvert.SerializeObject( result );

            var body = Encoding.UTF8.GetBytes( messageJson );

            channel.BasicPublish(
                        exchange: "infracciones.transito",
                        routingKey: "infracciones.transito.envigado",
                        body: body
                        );
        }
    }
}
