using Microsoft.AspNetCore.Mvc;
using ProdutosApiAula.Models;
using ProdutosApiAula.Repositories;
using System.Linq;

namespace ProdutosApiAula.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        [HttpGet(Name = "GetProdutos")]
        public IEnumerable<Produto> Get()
        {
            return MockDB.GetProdutos();
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public Produto GetProduto(int id)
        {
            return MockDB.GetProduto(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            MockDB.Produtos.Add(produto);
            return CreatedAtRoute("GetProduto", new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            var existingProduto = MockDB.GetProduto(id);

            if (existingProduto == null)
            {
                return NotFound();
            }

            existingProduto.Name = produto.Name;
            existingProduto.Price = produto.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = MockDB.GetProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            MockDB.Produtos.Remove(produto);

            return NoContent();
        }
    }
}
