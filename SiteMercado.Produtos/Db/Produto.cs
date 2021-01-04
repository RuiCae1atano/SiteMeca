using System;
using System.Collections.Generic;

#nullable disable

namespace SiteMercado.Api.Produtos.Db
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Imagem { get; set; }
    }
}
