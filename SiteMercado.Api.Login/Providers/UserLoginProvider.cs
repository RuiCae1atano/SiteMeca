using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using SiteMercado.Api.Login.Intefaces;
using SiteMercado.Api.Login.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiteMercado.Api.Login.Providers
{
    public class UserLoginProvider : IUserLogin
    {
        HttpClient client = new HttpClient();
        string uri = "https://dev.sitemercado.com.br/api/login";

        public UserLoginProvider()
        {
        }

        public string CreateToken(Usuario user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Password)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);


            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public JObject LoginUser(Usuario user)
        {
            JObject js = new JObject();
            js["Username"] = user.Username;
            js["Password"] = user.Password;

            try
            {
                client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                        "Basic", Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                        $"{"11234567890"}:{"09876543211"}")));

                var result = client.PostAsync(uri, user, new JsonMediaTypeFormatter()).Result;

                if (result.IsSuccessStatusCode)
                {
                    //CreateToken(user);
                    return (JObject.Parse(result.Content.ReadAsStringAsync().Result));
                }
            }
            catch (Exception ex)
            {

                return JObject.Parse(ex.ToString());
            }

            return null;
        }
    }
}
