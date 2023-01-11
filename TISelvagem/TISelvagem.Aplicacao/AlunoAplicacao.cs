using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiSelvagem.Dominio;
using TiSelvagem.Repositorio;

namespace TISelvagem.Aplicacao
{
    public class AlunoAplicacao
    {
        private Contexto contexto;

        private void Inserir(Aluno aluno)
        {
            var strQuery = "";
            strQuery += " INSERT INTO alunos (Nome, Mae, Data_Nasc) ";
            strQuery += String.Format($" VALUES ('{aluno.Nome}', '{aluno.Mae}', '{aluno.DataNascimento}') "
            );
            using (contexto = new Contexto())
            {
                contexto.executaComando(strQuery);
            }
        }

        private void Alterar(Aluno aluno)
        {
            var strQuery = "";
            strQuery += " UPDATE alunos SET ";
            strQuery += String.Format($" Nome = '{aluno.Nome}', ");
            strQuery += String.Format($" Mae = '{aluno.Mae}', ");
            strQuery += String.Format($" Data_Nasc = '{aluno.DataNascimento}' ");
            strQuery += String.Format($" WHERE AlunoId = '{aluno.Id}' ");
            using (contexto = new Contexto())
            {
                contexto.executaComando(strQuery);
            }
        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.Id > 0)
                Alterar(aluno);
            else
            {
                Inserir(aluno);
            }

        }

        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format($" DELETE FROM alunos WHERE AlunoId = {id}");
                contexto.executaComando(strQuery);
            }
        }

        public List<Aluno> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM alunos ";
                var retornoDataReader = contexto.executaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Aluno ListarPorId(int Id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM alunos WHERE AlunoId = {0}", Id);
                var retornoDataReader = contexto.executaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var tempObjeto = new Aluno()
                {
                    Id = int.Parse(reader["AlunoId"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Mae = reader["Mae"].ToString(),
                    DataNascimento = DateTime.Parse(reader["Data_Nasc"].ToString())
                };
                alunos.Add(tempObjeto);
            }
            reader.Close();
            return alunos;
        }
    }
}
