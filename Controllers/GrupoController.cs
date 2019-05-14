using ApiMySql.Model;
using ApiMySql.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiMySql.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
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
            var Grupoes = _GrupoRepository.GetAll();

            if (Grupoes.Count() == 0)
                return NoContent();

            return Ok(Grupoes);
        }

        [HttpPost]
        [Produces(typeof(Grupo))]
        public IActionResult Post([FromBody]Grupo Grupo)
        {
             _GrupoRepository.Add(Grupo);
            
            return Ok(Grupo);
        }
    }
}