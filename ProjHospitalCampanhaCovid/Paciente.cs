using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class Paciente
    {
        #region Atributos do Paciente

        public string Nome { get; set; }
        public int CPF { get; set; }
        public static int Senha { get; set; }
        public string DataDeNascimento { get; set; }
        public Relatorio[] Relatorios { get; set; }

        #endregion

        #region Construtor

        public Paciente(string nome, int cpf, string dataDeNascimento)
        {
            Nome = nome;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
        }

        #endregion

    }
}
