using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Dominio;
using Ecommerce.Aplicacao;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            var appProduto = new EcommerceAplicacao();

            Console.Write("Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("Valor do Produto: ");
            string preco = Console.ReadLine();

            var produto1 = new Produto
            {
                Nome = nome,
                Preco = preco
            };
            
            appProduto.Salvar(produto1);
            
            var dados = appProduto.ListarTodos();

            foreach (var produto in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Preço:{2}", produto.Id, produto.Nome, produto.Preco);
            }
            Console.ReadLine();
        }
    }
}
