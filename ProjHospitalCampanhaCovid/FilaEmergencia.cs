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

        #region Variáveis

        int quantidade = 0;

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
                if (novoPaciente.Relatorios.QuantidadeDeComorbidades > Head.Relatorios.QuantidadeDeComorbidades)
                {
                    novoPaciente.Proximo = Head;
                    Head.Anterior = novoPaciente;
                    Head = novoPaciente;

                }
                else
                {
                    if (novoPaciente.Relatorios.QuantidadeDeComorbidades < Head.Relatorios.QuantidadeDeComorbidades)
                    {
                        Tail.Proximo = novoPaciente;
                        novoPaciente.Anterior = Tail;
                        Tail = novoPaciente;
                    }
                    else
                    {
                        Paciente aux1 = Head;
                        do
                        {
                            if (String.Compare(novoPaciente.CPF, aux1.CPF) >= 0)
                            {
                                aux1 = aux1.Proximo;
                            }
                            else
                            {
                                novoPaciente.Proximo = aux1;
                                novoPaciente.Anterior = aux1.Anterior;
                                novoPaciente.Anterior.Proximo = novoPaciente;
                                aux1.Anterior = novoPaciente;
                                aux1 = aux1.Proximo;
                            }
                        } while (aux1 != null);
                    }
                }
                Console.Clear();
            }
            quantidade++;
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

        public Paciente Saida()
        {
            Paciente aux = Head;
            if (Head.Proximo == null)
            {
                Tail = null;
            }
            Head = Head.Proximo;
            return aux;
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
                    aux = aux.Proximo;
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
