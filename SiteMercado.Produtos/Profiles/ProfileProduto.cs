using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.Api.Produtos.Profiles
{
    public class ProfileProduto : AutoMapper.Profile
    {
        public ProfileProduto()
        {
            CreateMap<Db.Produto, Models.Produto>();
            CreateMap<Models.Produto, Db.Produto>();
        }
    }
}
