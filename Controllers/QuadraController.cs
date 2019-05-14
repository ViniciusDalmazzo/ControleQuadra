using ApiMySql.Model;
using ApiMySql.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiMySql.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    public class QuadraController : ControllerBase
    {
        private readonly IQuadraRepository _QuadraRepository;

        public QuadraController(IQuadraRepository QuadraRepository)
        {
            _QuadraRepository = QuadraRepository;
        }

        [HttpGet]
        [Produces(typeof(Quadra))]
        public IActionResult Get()
        {
            var Quadras = _QuadraRepository.GetAll();

            if (Quadras.Count() == 0)
                return NoContent();

            return Ok(Quadras);
        }

        [HttpPost]
        [Produces(typeof(Quadra))]
        public IActionResult Post([FromBody]Quadra Quadra)
        {
             _QuadraRepository.Add(Quadra);
            
            return Ok(Quadra);
        }
    }
}