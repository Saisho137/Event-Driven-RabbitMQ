using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiPracticaTransito.Models;
using RabbitMQ.Client;
using System.Text;

namespace ApiPracticaTransito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransitoController : ControllerBase
    {
        [HttpPost]
        [Route("api/registrarInfraccion")]
        public responseInfraccion RegistrarInfraccion([FromBody] requestInfraccion peticion)
        {
            Class publicador = new Class();
            responseInfraccion result = new responseInfraccion();
            result.placa = peticion.placa;
            result.codigoInfraccion = peticion.codigoInfraccion;
            result.momentoInfraccion = peticion.fechaInfraccion.ToString() + "T" + peticion.horaInfraccion.ToString();
            publicador.Publisher(result);
            return result;
        }
    }
}
