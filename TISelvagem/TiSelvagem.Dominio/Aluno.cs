using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiSelvagem.Dominio
{
    public class Aluno
    {
        public int Id { get; set; }

        [DisplayName("Nome do Aluno")]
        public string Nome { get; set; }

        [DisplayName("Mãe")]
        public string Mae { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
