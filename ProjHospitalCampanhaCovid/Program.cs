using System;

namespace ProjHospitalCampanhaCovid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variáveis

            string opcao;

            #endregion

            #region Inicialização de Classes

            ControleDeFluxoDePacientes controle = new ControleDeFluxoDePacientes();

            #endregion

            #region Opções do Menu

            do
            {
                Console.Clear();
                opcao = MenuPrincipal();
                switch (opcao)
                {
                    case "0":
                        break;
                    case "1":
                        controle.InserirPaciente();
                        break;
                    case "2":
                        controle.Recepcao();
                        break;
                    case "3":
                        controle.Triagem();
                        break;
                    case "4":
                        ListaDeArquivados();
                        break;
                    case "5":
                        FilaCovid();
                        break;
                    case "6":
                        ListaDeEmergencia();
                        break;
                    case "7":
                        Internacao();
                        break;
                }
            } while (opcao != "0");

            #endregion

            #region Menu Principal

            string MenuPrincipal()
            {
                Console.Clear();
                Console.WriteLine("Sistema COVID");
                Console.WriteLine("1 - Entrada de Paciente");
                Console.WriteLine("2 - Recepção");
                Console.WriteLine("3 - Triagem");
                Console.WriteLine("4 - Lista de Arquivados");
                Console.WriteLine("5 - Fila Covid");
                Console.WriteLine("6 - Fila de Emergência");
                Console.WriteLine("7 - Internaçãos");
                Console.WriteLine("0 - Sair");
                return Console.ReadLine();
            }

            #endregion

            #region Lista de Emergência 

            void ListaDeEmergencia()
            {
                string opcao = "a";
                do
                {
                    Console.Clear();
                    Console.WriteLine("Fila de Emergência");
                    Console.WriteLine("1 - Buscar Paciente");
                    Console.WriteLine("2 - Buscar Paciente Para Alta");
                    Console.WriteLine("3 - Imprimir Lista de Emergência");
                    Console.WriteLine("4 - Adicionar Paciente a Fila de Emergência");
                    Console.WriteLine("0 - Sair");
                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            controle.ListaDePacientesArquivados.BuscarArquivado();
                            break;
                        case "2":
                            break;
                        case "3":
                            controle.ListaDePacientesArquivados.ImprimirListaDePacientesArquivados();
                            break;
                        case "4":
                            break;
                    }
                } while (opcao != "0");

            }

            #endregion

            #region Internação

            void Internacao()
            {
                string opcao = "a";

                do
                {
                    Console.Clear();
                    Console.WriteLine("Internação");
                    Console.WriteLine("1 - Buscar Paciente");
                    Console.WriteLine("2 - Imprimir Lista de Internação");
                    Console.WriteLine("3 - Quantidade de Leitos Disponíveis");
                    Console.WriteLine("4 - Alterar Quantidade de Leitos");
                    Console.WriteLine("0 - Sair");
                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            controle.Internacao.BuscarInternacao();
                            break;
                        case "2":
                            controle.Internacao.ImprimirInternacao();
                            break;
                        case "3":
                            controle.Internacao.VerificarLeitos();
                            break;
                        case "4":
                            controle.Internacao.Leitos();
                            break;
                    }
                } while (opcao != "0");

            }

            #endregion

            #region Lista de Arquivados

            void ListaDeArquivados()
            {
                string opcao = "a";
                do
                {
                    Console.Clear();
                    Console.WriteLine("Lista de Arquivados");
                    Console.WriteLine("1 - Buscar Paciente");
                    Console.WriteLine("2 - Imprimir Lista de Arquivados");
                    Console.WriteLine("0 - Sair");
                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            controle.ListaDePacientesArquivados.BuscarArquivado();
                            break;
                        case "2":
                            controle.ListaDePacientesArquivados.ImprimirListaDePacientesArquivados();
                            break;
                    }
                } while (opcao != "0");
            }

            #endregion

            #region Fila Covid

            void FilaCovid()
            {
                string opcao = "a";
                do
                {
                    Console.Clear();
                    Console.WriteLine("Fila Covid");
                    Console.WriteLine("1 - Buscar Paciente");
                    Console.WriteLine("2 - Imprimir Fila Covid");
                    Console.WriteLine("0 - Sair");
                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            controle.FilaCovid.BuscarFilaCovid();
                            break;
                        case "2":
                            controle.FilaCovid.ImprimirFilaCovid();
                            break;
                    }
                } while (opcao != "0");
            }

            #endregion
        }
    }
}
