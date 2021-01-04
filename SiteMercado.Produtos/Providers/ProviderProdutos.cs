using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiteMercado.Api.Produtos.Db;
using SiteMercado.Api.Produtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.Api.Produtos.Providers
{
    public class ProviderProdutos : IProdutosProvider
    {
        private readonly SiteMercadoContext dbContext;
        private readonly ILogger<ProviderProdutos> logger;
        private readonly IMapper mapper;

        public ProviderProdutos(SiteMercadoContext dbContext, ILogger<ProviderProdutos> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }


        public (bool IsSuccess, string ErrorMessage) CadastraProduto(Models.Produto produto)
        {
            try
            {
                var prod = mapper.Map<Models.Produto, Db.Produto>(produto);
                dbContext.Produtos.Add(prod);
                dbContext.SaveChanges();
            }
            catch (Exception ex) 
            {
                {
                    logger?.LogError(ex.ToString());
                    return (false, ex.Message);
                }
            }

            return (true, "Cadastro efetuado com sucesso");
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> DeletaProdutoAsync(int id)
        {
            try
            {
                var products = await dbContext.Produtos.FirstOrDefaultAsync(p => p.Id == id);
                if (products != null)
                {
                    dbContext.Produtos.Remove(products);
                    dbContext.SaveChanges();
                    return (true, "Produto Deletado com sucesso");
                }
                return (false, "Não foi possível deletar o produto");
            }
            catch (Exception ex)
            {
                {
                    logger?.LogError(ex.ToString());
                    return (false, ex.Message);
                }
            }
        }

        public (bool IsSuccess, string ErrorMessage) EditaProdutoAsync(int id, Models.Produto produto)
        {
            try
            {
                    var prod = mapper.Map<Models.Produto, Db.Produto>(produto);
                    dbContext.Produtos.Update(prod);
                    dbContext.SaveChanges();
                    return (true, "Produto alterado com sucesso");
            }
            catch (Exception ex)
            {
                {
                    logger?.LogError(ex.ToString());
                    return (false, ex.Message);
                    //throw;
                }
            }
        }


        public async Task<(bool IsSuccess, IEnumerable<Models.Produto> produtos, string ErrorMessage)> ListaProdutoAsync()
        {
            try
            {
                var products = await dbContext.Produtos.ToListAsync();
                if (products != null && products.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Produto>, IEnumerable<Models.Produto>>(products);
                    return (true, result, null);
                }
                return (false, null, "NotFound");
            }
            catch (Exception exception)
            {
                logger?.LogError(exception.ToString());
                return (false, null, exception.Message);
            }
        }


        public async Task<(bool IsSuccess, Models.Produto, string ErrorMessage)> MostraProdutoAsync(int id)
        {
            try
            {
                var products =  await dbContext.Produtos.FirstOrDefaultAsync(p => p.Id == id);
              

                if (products != null)
                {
                    var result = mapper.Map<Db.Produto, Models.Produto>(products);
                    return (true, result, null);
                }
                return (false,null , "Não foi possível deletar o produto");
            }
            catch (Exception ex)
            {
                {
                    logger?.LogError(ex.ToString());
                    return (false,null, ex.Message);
                }
            }
        }
    }
}
