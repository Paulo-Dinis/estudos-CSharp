using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Ecommerce.Dominio;
using Ecommerce.Repositorio;

namespace Ecommerce.Aplicacao
{
    public class EcommerceAplicacao
    {
        private Contexto contexto;

        private void Inserir(Produto produto)
        {
            var strQuery = "";
            strQuery += "INSERT INTO Produto ";
            strQuery += String.Format(" VALUES ('{0}', '{1}') ", produto.Nome, produto.Preco);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

            var strQueryImg = "";
            strQueryImg += String.Format(" SELECT * FROM Produto ");
            var retornoDataReader = new Contexto().ExecutaComandoComRetorno(strQueryImg);
            var idImagem = TransformaReaderEmListaDeObjeto(retornoDataReader).LastOrDefault();

            string caminhoArquivo = @"C:\Users\Paulo\Documents\visual studio 2015\Projects\Ecommerce\Ecommerce.UI.Web\upload-image\produtos\" + idImagem.Id + ".jpg";

            var batata = produto.imagem.FirstOrDefault().Split(',')[1];
            var abacate = Convert.FromBase64String(batata);
            System.IO.File.WriteAllBytes(caminhoArquivo, abacate);
        }

        private void Alterar(Produto produto)
        {
            var strQuery = "";
            strQuery += " UPDATE Produto SET ";
            strQuery += String.Format(" nome = '{0}', ", produto.Nome);
            strQuery += String.Format(" preco = '{0}' ", produto.Preco);
            strQuery += String.Format(" WHERE id_produto = {0} ", produto.Id);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Produto produto)
        {
            if (produto.Id > 0)
            {
                Alterar(produto);
            }
            else
            {
                Inserir(produto);
            }
        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = String.Format(" DELETE FROM Produto WHERE id_produto = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Carrinho(int id)
        {
            var strQuery = ""; 
            strQuery += "INSERT INTO Carrinho ";
            strQuery += String.Format(" VALUES ('{0}') ", id);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void ExcluirDoCarrinho(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = String.Format(" DELETE FROM Carrinho WHERE id_produto_carrinho = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public void LimparCarrinho()
        {
            using (contexto = new Contexto())
            {
                var strQuery = (" DELETE FROM Carrinho");
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Produto> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM Produto ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Produto ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = String.Format(" SELECT * FROM Produto WHERE id_produto = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        public List<Produto> ListarCarrinho()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "";
                strQuery += "SELECT A.id_produto, id_produto_carrinho, nome, preco ";
                strQuery += "FROM Produto A ";
                strQuery += "INNER JOIN Carrinho C ";
                strQuery += "ON a.id_produto = c.id_produto ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjetoCarrinho(retornoDataReader);
            }
        }

        private List<Produto> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var produtos = new List<Produto>();
            while (reader.Read())
            {
                var tempObjeto = new Produto()
                {
                    Id = int.Parse(reader["id_produto"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Preco = reader["preco"].ToString()
                };
                produtos.Add(tempObjeto);
            }
            reader.Close();
            return produtos;
        }

        private List<Produto> TransformaReaderEmListaDeObjetoCarrinho(SqlDataReader reader)
        {
            var produtos = new List<Produto>();
            while (reader.Read())
            {
                var tempObjeto = new Produto()
                {
                    Id = int.Parse(reader["id_produto"].ToString()),
                    Id_produtoCarrinho = int.Parse(reader["id_produto_carrinho"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Preco = reader["preco"].ToString()
                };
                produtos.Add(tempObjeto);
            }
            reader.Close();
            return produtos;
        }


    }
}
