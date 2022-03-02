using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class Relatorio
    {
        #region Atributos/Propriedades do Relatório

        public float Temperatura { get; set; }
        public string Pressao { get; set; }
        public int Saturacao { get; set; }
        public string DataInicioSintomas { get; set; }
        public string Comorbidades { get; set; }
        public int QuantidadeDeComorbidades { get; set; }

        #endregion

        #region Construtor

        public Relatorio(float temperatura, string pressao, int saturacao, string dataInicioSintomas, string comorbidades, int quantidadeDeComorbidades)
        {
            Temperatura = temperatura;
            Pressao = pressao;
            Saturacao = saturacao;
            DataInicioSintomas = dataInicioSintomas;
            Comorbidades = comorbidades;
            QuantidadeDeComorbidades = quantidadeDeComorbidades;
        }

        #endregion

        #region Métodos



        #endregion

        #region Métodos de sobreescrita

        public override string ToString()
        {
            return "\n\n----- Início do Relatório da Anamnese -----\nTemperatura: " + Temperatura + "\nPressão: " + Pressao
                + "\nSaturação: " + Saturacao + "\nData de Início dos Sintomas: " + DataInicioSintomas
                + "\nComorbidades: " + Comorbidades + "\nQuantidade de Comorbidades: "
                + QuantidadeDeComorbidades + "\n\n----- Fim do Relatório da Anamnese -----";
        }


        #endregion
    }
}
