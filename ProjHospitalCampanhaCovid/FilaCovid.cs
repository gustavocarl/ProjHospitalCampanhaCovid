using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class FilaCovid
    {
        #region Atributos/Propriedades Fila Covid

        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        #endregion

        #region Construtor

        public FilaCovid()
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

        public void ImprimirFilaCovid()
        {
            Console.Clear();
            if (Vazio())
            {
                Console.WriteLine("Nenhum Paciente na Fila de Covid");
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

        public void BuscarFilaCovid()
        {
            Console.Clear();
            if (Vazio())
            {
                Console.WriteLine("Nenhum Paciente na Fila de Covid");
            }
            else
            {
                Console.WriteLine("Informe o CPF do Paciente que deseja buscar");
                string buscarPaciente = Console.ReadLine();
                Paciente aux = Head;
                bool pacienteNaoEncontrado = false;
                do
                {
                    if (aux.CPF.Contains(buscarPaciente))
                    {
                        Console.WriteLine(aux.ToString());
                        Console.WriteLine(aux.Relatorios.ToString());
                        pacienteNaoEncontrado = true;
                    }
                } while (aux != null);
                if (pacienteNaoEncontrado == false)
                {
                    Console.WriteLine("Nenhum Paciente Encontrado");
                }
            }
            Console.ReadKey();
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
