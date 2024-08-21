using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using System.Threading.Tasks;

namespace TPProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IGraphClient _client;

        public ProductosController(IGraphClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _client.Cypher
                .Match("(p:Producto)")
                .Return(p => p.As<dynamic>())
                .ResultsAsync;

            return Ok(productos);
        }
    }
}

