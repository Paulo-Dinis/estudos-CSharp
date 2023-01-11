using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiSelvagem.Dominio;
using TISelvagem.Aplicacao;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o nome da mãe aluno: ");
            string mae = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento: ");
            string data = Console.ReadLine();

            var aluno1 = new Aluno
            {
                Nome = nome,
                Mae = mae,
                DataNascimento = DateTime.Parse(data)
            };

            var appAluno = new AlunoAplicacao();

            appAluno.Salvar(aluno1);

            var dados = appAluno.ListarTodos();

            foreach (var aluno in dados)
            {
                Console.WriteLine($"Id:{aluno.Id}, Nome:{aluno.Nome}, Mae:{aluno.Mae}, DataNascimento:{aluno.DataNascimento}");
            }
        }
    }
}
