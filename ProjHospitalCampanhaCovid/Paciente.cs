using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class Paciente
    {
        #region Atributos/Propriedades do Paciente

        public int Senha { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public Relatorio Relatorios { get; set; }
        public Paciente Proximo { get; set; }

        #endregion

        #region Construtor

        public Paciente(string nome, string cpf, DateTime dataDeNascimento)
        {
            Nome = nome;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
            Proximo = null;
        }

        public Paciente(int senha)
        {
            Senha = senha;
        }

        public Paciente(Paciente paciente, Relatorio relatorio)
        {
            Nome = paciente.Nome;
            CPF = paciente.CPF;
            DataDeNascimento = paciente.DataDeNascimento;
            Relatorios = relatorio;
        }

        public Paciente(string nome, string cpf, DateTime dataDeNascimento, Relatorio relatorio)
        {
            Nome = nome;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
            Relatorios = relatorio;
            Proximo = null;
        }

        #endregion

        #region Métodos de sobreescrita

        public override string ToString()
        {
            return "----- Inicio dos Dados do Paciente -----\n\nNome:" + Nome + "\nCPF: " + CPF
                + "\nData de Nascimento: " + DataDeNascimento.ToString("dd/MM/yyyy")
                + "\n\n----- Fim dos Dados do Paciente -----";
        }

        #endregion
    }
}
