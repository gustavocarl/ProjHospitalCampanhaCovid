using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class FilaEmergencia
    {
        #region Atributos/Propriedades da Fila de Emergência

        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        #endregion

        #region Construtor

        public FilaEmergencia()
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

        public void ImprimirFilaDeEmergencia()
        {
            Console.Clear();
            if (Vazio())
            {
                Console.WriteLine("Nenhum Paciente na Fila de Emergência");
                Console.WriteLine("Pressione ENTER para continuar...");
            }
            else
            {
                Paciente aux = Head;
                do
                {
                    Console.WriteLine(aux);
                    Console.WriteLine(aux.Relatorios.ToString());
                    aux = aux.Proximo;
                } while (aux != null);
            }
            Console.ReadKey();
        }

        public void BuscarEmergencia()
        {
            Console.Clear();
            if (Vazio())
            {
                Console.WriteLine("Nenhum Paciente na Fila de Emergência");
                Console.WriteLine("Pressione ENTER para continuar...");
            }
            else
            {
                Console.WriteLine("Informe o CPF do Paciente que deseja buscar: ");
                string busca = Console.ReadLine();
                Paciente aux = Head;
                bool pacienteNaoEncontrado = false;
                do
                {
                    Console.WriteLine(aux.ToString());
                    Console.WriteLine(aux.Relatorios.ToString());
                    pacienteNaoEncontrado = true;
                } while (aux != null);
                if (pacienteNaoEncontrado == false)
                {
                    Console.WriteLine("Nenhum Paciente Encontrado");
                    Console.WriteLine("Pressione ENTER para continuar...");
                }
                Console.ReadKey();
            }
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
