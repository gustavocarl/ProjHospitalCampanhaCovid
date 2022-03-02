using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class Internacao
    {
        #region Atributos/Propriedades da Classe Internação

        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        #endregion

        #region Variáveis

        int quantidadeTotalDeLeitos = 0;

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

        public void ImprimirInternacao()
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

        public void BuscarInternacao()
        {
            Console.Clear();
            if (Vazio())
            {
                Console.WriteLine("Não Há Nenhum Paciente na Internação");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Informe o CPF do Paciente que deseja buscar");
                string busca = Console.ReadLine();
                Paciente aux = Head;
                bool pacienteNaoEncontrado = false;
                do
                {
                    if (aux.CPF.Contains(busca))
                    {
                        Console.WriteLine(aux.ToString());
                        Console.WriteLine(aux.Relatorios.ToString());
                        pacienteNaoEncontrado = true;
                    }
                    aux = aux.Proximo;
                } while (aux != null);
                if (pacienteNaoEncontrado == false)
                {
                    Console.WriteLine("Nenhum Paciente Encontrado");
                }
                Console.ReadKey();
            }
        }

        public void Leitos()
        {
            Console.WriteLine("Informe a Quantidade Total de Leitos no Hospital: ");
            int leitos = int.Parse(Console.ReadLine());
            if (Contador() > leitos)
            {
                Console.WriteLine($"O Hospital já poussi {Contador()} leitos ocupados\nVerificar e Informar a quantidade de leitos correta");
            }
            else
            {
                Console.WriteLine("Quantidade Leitos Atualizada");
                quantidadeTotalDeLeitos = leitos;
            }
            Console.ReadKey();
        }

        int Contador()
        {
            int contarLeitos = 1;
            if (Vazio())
            {
                contarLeitos = 0;
            }
            else
            {
                Paciente aux = Head;
                do
                {
                    aux = aux.Proximo;
                    contarLeitos++;
                } while (aux != null);
            }
            return contarLeitos;
        }

        public void VerificarLeitos()
        {
            if (quantidadeTotalDeLeitos >= Contador())
            {
                Console.WriteLine($"Há um total {quantidadeTotalDeLeitos - Contador()} leitos disponíveis");
            }
            else
            {
                Console.WriteLine("Não há leitos disponíveis");
                Console.WriteLine("Paciente foi adicionado a Fila de Espera de Internação");
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
