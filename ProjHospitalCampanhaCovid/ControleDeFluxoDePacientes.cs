using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class ControleDeFluxoDePacientes
    {
        #region Propriedades

        public int[] FilaDeEntrada { get; set; }
        public int Contador { get; set; }
        public int[] OutraFila { get; set; }

        #endregion


        #region Construtor

        public ControleDeFluxoDePacientes()
        {
            FilaDeEntrada = new int[50]; // Instância um vetor;
        }

        #endregion

        #region Métodos 

        public void Entrada()
        {
            Contador++;
            FilaDeEntrada[Contador - 1] = Contador;
        }

        public void EntradaTriagem()
        {
            int aux;
            FilaDeEntrada[Contador] = aux;
            Contador--;
            OutraFila[Contador] = aux;
        }
        #endregion
    }
}
