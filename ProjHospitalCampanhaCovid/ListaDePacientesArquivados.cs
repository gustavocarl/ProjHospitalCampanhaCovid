using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class ListaDePacientesArquivados
    {
        #region Atributos/Propriedades da Lista De Pacientes Arquivados

        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        #endregion

        #region Construtor

        public ListaDePacientesArquivados()
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

        public void ImprimirListaDePacientesArquivados()
        {
            if (Vazio())
            {
                Console.WriteLine("A Fila de Pacientes Arquivados está vazia");
                Console.WriteLine("Pressione a Tecla ENTER Para Continuar");
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

        public void BuscarArquivado()
        {
            Console.Clear();
            if (Vazio())
            {
                Console.WriteLine("Não contém nenhum Paciente na Lista de Arquivados");
                Console.WriteLine("Pressione a Tecla ENTER Para Continuar");
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
                    aux = aux.Proximo;
                } while (aux != null);
                if (pacienteNaoEncontrado == false)
                {
                    Console.WriteLine("Nenhum Paciente Encontrado na Lista de Arquivados");
                    Console.WriteLine("Pressione a Tecla ENTER Para Continuar");
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
