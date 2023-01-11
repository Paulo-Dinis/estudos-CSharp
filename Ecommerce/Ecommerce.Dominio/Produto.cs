using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Collections.Generic;

namespace Ecommerce.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public int Id_produtoCarrinho { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Id_imagem => Id + ".jpg";
        public List<string> imagem { get; set; }
    }
}
