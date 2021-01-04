using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.Api.Login.Intefaces
{
    public interface IUserLogin
    {
        JObject LoginUser(Models.Usuario user);
    }
}
