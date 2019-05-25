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
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoRepository _GrupoRepository;

        public GrupoController(IGrupoRepository GrupoRepository)
        {
            _GrupoRepository = GrupoRepository;
        }

        [HttpGet]
        [Produces(typeof(Grupo))]
        public IActionResult Get()
        {
            var Grupos = _GrupoRepository.GetAll();

            if (Grupos.Count() == 0)
                return NoContent();

            return Ok(Grupos);
        }

        [HttpPost]
        [Produces(typeof(Grupo))]
        public IActionResult Post([FromBody]Grupo Grupo)
        {
             _GrupoRepository.Add(Grupo);
            
            return Ok(Grupo);
        }

        [HttpPost]
        [Produces(typeof(Grupo))]
        [Route("/api/[controller]/GrupoDeJogador")]
        public IActionResult Post([FromBody]GrupoJogadorDTO GrupoJogador)
        {
            _GrupoRepository.AddGrupoJogador(GrupoJogador);

            return Ok(GrupoJogador);
        }
    }
}