using ApiMySql.Model;
using ApiMySql.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiMySql.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class JogadorController : ControllerBase
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorController(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }

        [HttpGet]
        [Produces(typeof(Jogador))]
        public IActionResult Get()
        {
            var jogadores = _jogadorRepository.GetAll();

            if (jogadores.Count() == 0)
                return NoContent();

            return Ok(jogadores);
        }

        [HttpPost]
        [Produces(typeof(Jogador))]
        public IActionResult Post([FromBody]Jogador jogador)
        {
             _jogadorRepository.Add(jogador);
            
            return Ok(jogador);
        }
    }
}