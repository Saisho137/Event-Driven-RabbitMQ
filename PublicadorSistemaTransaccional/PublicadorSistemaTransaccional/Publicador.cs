using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicadorSistemaTransaccional
{
    public class Publicador
    {
        public void Publisher(Model result)
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
            var messageJson = JsonConvert.SerializeObject(result);

            var body = Encoding.UTF8.GetBytes(messageJson);

            channel.BasicPublish(
                        exchange: "operaciones.bancarias",
                        routingKey: "inscripcion.bancaria",
                        body: body
                        );
        }
    }
}
