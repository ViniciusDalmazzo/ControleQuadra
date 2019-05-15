using ApiMySql.Model;
using ApiMySql.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiMySql.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _AgendamentoRepository;

        public AgendamentoController(IAgendamentoRepository AgendamentoRepository)
        {
            _AgendamentoRepository = AgendamentoRepository;
        }

        [HttpGet]
        [Produces(typeof(Agendamento))]
        public IActionResult Get()
        {
            var Agendamentoes = _AgendamentoRepository.GetAll();

            if (Agendamentoes.Count() == 0)
                return NoContent();

            return Ok(Agendamentoes);
        }

        [HttpPost]
        [Produces(typeof(Agendamento))]
        public IActionResult Post([FromBody]Agendamento Agendamento)
        {
            ReserveResponseDTO reserveResponseDTO = _AgendamentoRepository.Add(Agendamento);

            if (!reserveResponseDTO.status)
                return NotFound();
            
            return Ok(Agendamento);
        }
        
    }
}