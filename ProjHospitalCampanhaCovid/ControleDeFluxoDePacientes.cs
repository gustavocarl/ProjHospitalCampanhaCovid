using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class ControleDeFluxoDePacientes
    {
        #region Atributos/Propriedades do Controle de Fluxo de Pacientes

        public FilaDeEntrada FilaDeEntrada { get; set; }
        public FilaPadrao FilaPadrao { get; set; }
        public FilaPreferencial FilaPreferencial { get; set; }
        public ListaDePacientesArquivados ListaDePacientesArquivados { get; set; }
        public FilaCovid FilaCovid { get; set; }
        public Internacao Internacao { get; set; }
        public FilaEmergencia FilaEmergencia { get; set; }

        #endregion

        #region Variáveis

        int pacientesPreferenciais = 0;

        #endregion

        #region Construtor

        public ControleDeFluxoDePacientes()
        {
            FilaDeEntrada = new FilaDeEntrada();
            FilaPreferencial = new FilaPreferencial();
            FilaPadrao = new FilaPadrao();
            ListaDePacientesArquivados = new ListaDePacientesArquivados();
            FilaCovid = new FilaCovid();
            Internacao = new Internacao();
            FilaEmergencia = new FilaEmergencia();
        }

        #endregion

        #region Métodos 

        public void InserirPaciente()
        {
            string selecao;
            do
            {
                Console.WriteLine("Entrada de Paciente");
                Console.WriteLine("\nDeseja adicionar um novo paciente a fila de entrada");
                Console.WriteLine("1 - Sim\n2 - Não");
                selecao = Console.ReadLine();
                if (selecao == "1")
                {
                    FilaDeEntrada.Entrada(new Paciente(FilaDeEntrada.GerarSenha));
                    Console.WriteLine($"A senha do paciente é: {FilaDeEntrada.GerarSenha}");
                }
            } while (selecao != "2");
        }

        public void Recepcao()
        {
            Console.Clear();
            if (FilaDeEntrada.Vazio())
            {
                Console.WriteLine("A fila de entrada não contém pacientes a serem chamados");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadKey();
            }
            else
            {
                FilaDeEntrada.PuxarPaciente();
                Console.WriteLine("Informe o Nome do Paciente: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Informe o CPF do Paciente");
                string cpf = Console.ReadLine();
                Console.WriteLine("Informe a Data de Nascimento: \nExemplo: 01/01/2022");
                DateTime dataDeNascimento = DateTime.Parse(Console.ReadLine());
                bool IdadeAcimaDe59Anos = ((DateTime.Now.Year - dataDeNascimento.Year) > 59);
                if (IdadeAcimaDe59Anos)
                {
                    FilaPreferencial.Entrada(new Paciente(nome, cpf, dataDeNascimento));
                }
                else
                {
                    FilaPadrao.Entrada(new Paciente(nome, cpf, dataDeNascimento));
                }
                Console.ReadLine();
            }
        }

        public void Triagem()
        {
            if (FilaPadrao.Vazio() && FilaPreferencial.Vazio())
            {
                Console.WriteLine("Nenhum Paciente nas filas para realizar triagem");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadKey();
            }
            else if ((FilaPreferencial.Vazio()) || (pacientesPreferenciais == 2))
            {
                CriarRelatorio(FilaPadrao.Saida());
                pacientesPreferenciais = 0;
            }
            else if (pacientesPreferenciais < 2)
            {
                CriarRelatorio(FilaPreferencial.Saida());
                pacientesPreferenciais++;
            }
        }

        public void CriarRelatorio(Paciente paciente)
        {
            string exameFeito = "", exameRealizado = "";
            bool selecao = false;
            string opcao = "a";
            Console.WriteLine(paciente.ToString());
            Console.WriteLine("Temperatura do Paciente: ");
            float temperatura = float.Parse(Console.ReadLine());
            Console.WriteLine("Pressão do Paciente: ");
            string pressao = Console.ReadLine();
            Console.WriteLine("Saturação do Paciente: ");
            int saturacao = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantidade de Dias do Início dos Sintomas: ");
            string dataInicioDosSintomas = Console.ReadLine();
            Console.WriteLine("Sintomas sentidos: ");
            string sintomas = Console.ReadLine();
            Console.WriteLine("Caso Possua Comorbidades Informe quais: ");
            string comorbidades = Console.ReadLine();
            Console.WriteLine("Quantidade de Comorbidades do Paciente: ");
            int quantidadeDeComorbidades = int.Parse(Console.ReadLine());
            Console.WriteLine("Solicitar Exame:\n1 - Sim\n2 - Não");
            string exame = Console.ReadLine();
            if (exame == "1")
            {
                exameRealizado = "Sim";
                Console.WriteLine("Resultado do Exame:\n1 - Positivo\n2 - Negativo");
                string resultadoExame = Console.ReadLine();
                if (resultadoExame == "1")
                {
                    exameFeito = "Positivo";
                }
                else if (resultadoExame == "2")
                {
                    exameFeito = "Negativo";
                }
            }
            else if (exame == "2")
            {
                exameRealizado = "Não";
            }
            do
            {
                Console.WriteLine("1 - Arquivar Paciente");
                Console.WriteLine("2 - Fila de Emergência");
                Console.WriteLine("3 - Fila Covid");
                opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    ListaDePacientesArquivados.Entrada(new Paciente(paciente, new Relatorio(temperatura, pressao, saturacao, dataInicioDosSintomas, comorbidades, quantidadeDeComorbidades, sintomas, exameRealizado, exameFeito)));
                    selecao = true;
                }
                else if (opcao == "2")
                {
                    FilaEmergencia.Entrada(new Paciente(paciente, new Relatorio(temperatura, pressao, saturacao, dataInicioDosSintomas, comorbidades, quantidadeDeComorbidades, sintomas, exameRealizado, exameFeito)));
                    selecao = true;
                }
                else if (opcao == "3")
                {
                    FilaCovid.Entrada(new Paciente(paciente, new Relatorio(temperatura, pressao, saturacao, dataInicioDosSintomas, comorbidades, quantidadeDeComorbidades, sintomas, exameRealizado, exameFeito)));
                    selecao = true;
                }
                else
                {
                    Console.WriteLine("Por Favor, Selecione uma das Opções Disponíveis");
                }
            } while (selecao != true);
        }

        public void InserirEmergencia()
        {
            Console.WriteLine("Dados do Paciente para Emergencia");
            Console.WriteLine("Informe o nome do Paciente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o CPF");
            string cpf = Console.ReadLine();
            Console.WriteLine("Informe a Data de Nascimento: \nExemplo: 01/01/2022");
            DateTime dataDeNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Informe a Temperatura:");
            float temperatura = float.Parse(Console.ReadLine());
            Console.WriteLine("Informe a Pressão: ");
            string pressao = Console.ReadLine();
            Console.WriteLine("Informe a Saturação: ");
            int saturacao = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantidade de Dias do Início dos Sintomas: ");
            string dataInicioSintomas = Console.ReadLine();
            Console.WriteLine("Sintomas sentidos: ");
            string sintomas = Console.ReadLine();
            Console.WriteLine("Caso Possua Comorbidades Informe quais: ");
            string comorbidades = Console.ReadLine();
            Console.WriteLine("Quantidade de Comorbidades do Paciente: ");
            int quantidadeDeComorbidades = int.Parse(Console.ReadLine());
            Console.WriteLine("Solicitar Exame:\n1 - Sim\n2 - Não");
            string exame = Console.ReadLine();
            Console.WriteLine("Resultado do Exame:\n1 - Positivo\n2 - Negativo");
            string resultadoExame = Console.ReadLine();
            FilaEmergencia.Entrada(new Paciente(nome, cpf, dataDeNascimento, new Relatorio(temperatura, pressao, saturacao, dataInicioSintomas, comorbidades, quantidadeDeComorbidades, sintomas, exame, resultadoExame)));
        }

        #endregion
    }
}
