using SiteMercado.Api.Produtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.Api.Produtos.Providers
{
    public interface IProdutosProvider
    {
        (bool IsSuccess, string ErrorMessage) CadastraProduto(Produto produto);
        (bool IsSuccess, string ErrorMessage) EditaProdutoAsync(int id, Produto produto);
        Task<(bool IsSuccess, Models.Produto, string ErrorMessage)> MostraProdutoAsync(int id);
        Task<(bool IsSuccess, IEnumerable<Produto> produtos, string ErrorMessage)> ListaProdutoAsync();
        Task<(bool IsSuccess, string ErrorMessage)> DeletaProdutoAsync(int id);
    }
}
