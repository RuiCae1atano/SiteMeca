using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMercado.Api.Produtos.Models;
using SiteMercado.Api.Produtos.Providers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteMercado.Api.Produtos.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosApiController : ControllerBase
    {
        private readonly IProdutosProvider produtosProvider;

        // GET: api/<ValuesController>

        public ProdutosApiController(IProdutosProvider produtosProvider)
        {
            this.produtosProvider = produtosProvider;
        }



        //CADASTRA POST api/<ValuesController>
        [HttpPost("AddProduto")]
        
        public IActionResult CadastraProduto([FromBody] Produto value)
        {
            var result = produtosProvider.CadastraProduto(value);
            if (result.IsSuccess)
            {
                //return Ok(result.IsSuccess);
                return Ok();
            }
            return NotFound(result.ErrorMessage);
        }

        //CADASTRA POST api/<ValuesController>
        [HttpGet("MostraProduto/{id}")]
        public async Task<IActionResult> MostraProdutoAsync(int id)
        {
            var result = await produtosProvider.MostraProdutoAsync(id);
            if (result.IsSuccess)
            {
                //return Ok(result.IsSuccess);
                return Ok(result.Item2);
            }
            return NotFound(result);
        }

        //EDIÇÃO DE PRODUTOS PUT api/<ValuesController>/5
        [HttpPut("EditaProduto/{id}")]
        
        public IActionResult EditaProduto( [FromBody] Produto value, int id)
        {
            var result =  produtosProvider.EditaProdutoAsync(id, value);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //lISTA DE PRODUTOS
        [HttpGet]
        public async Task<IActionResult> ListaProduto()
        {
            var result = await produtosProvider.ListaProdutoAsync();
            if (result.IsSuccess)
            {
                return Ok(result.produtos);
            }
            return NotFound();
        }

        // DELETE PRODUTOS api/<ValuesController>/5
        //[HttpDelete("{id}")]
        [HttpDelete("DeletaProduto/{id}")]       
        public async Task<IActionResult> Delete(int id)
        {
            var result = await produtosProvider.DeletaProdutoAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.IsSuccess);
            }
            return NotFound(result.IsSuccess);
        }
    }
}
