using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class FilaPreferencial
    {
        #region Atributos/Propriedades da Fila Preferencial

        public Paciente Head;
        public Paciente Tail;

        #endregion

        #region Construtor

        public FilaPreferencial()
        {
            Head = null;
            Tail = null;
        }

        #endregion

        #region Métodos

        public void Entrada(Paciente novoPaciente)
        {
            if (Vazio())
            {
                Head = novoPaciente;
                Tail = novoPaciente;
            }
            else
            {
                Tail.Proximo = novoPaciente;
                Tail = novoPaciente;
            }
        }

        public Paciente Saida()
        {
            Paciente aux = Head;
            if (Head.Proximo == null)
                Tail = null;
            Head = Head.Proximo;
            return aux;
        }

        public void ImprimirPacientePreferencial()
        {
            Paciente aux = Head;
            do
            {
                Console.WriteLine("Paciente Preferencial");
                Console.WriteLine(aux.ToString());
                aux = aux.Proximo;
            } while (aux != null);
        }

        public bool Vazio()
        {
            if ((Head == null) && (Tail == null))
                return true;
            else
                return false;
        }

        #endregion

    }
}
