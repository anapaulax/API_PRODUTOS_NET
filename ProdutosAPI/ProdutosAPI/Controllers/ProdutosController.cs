using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Models;
using ProdutosAPI.Repository.Interfaces;
using System.Linq;

namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repositorio;

        public ProdutosController(IProdutoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listaDeProdutos = _repositorio.ConsultaProdutos();

            if (!listaDeProdutos.Any())
            {
                return NoContent();
            }

            return Ok(listaDeProdutos);
        }

        [HttpPost]
        public Produto Post([FromBody] Produto produto)
        {
            return _repositorio.CadastraProduto(produto);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var produto = _repositorio.ConsultaProdutoPorId(id);

            if (!produto.Any())
            {
                return NotFound();
            }
            return Ok(produto);
        }
    }
}
