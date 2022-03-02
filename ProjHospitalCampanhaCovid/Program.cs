using System;

namespace ProjHospitalCampanhaCovid
{
    internal class Program
    {
        public static int MenuPrincipal()
        {
            int opcao = 0;
            string selecao;
            bool flag = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Sistema COVID");
                Console.WriteLine("1 - Entrada de Paciente\n2 - Buscar de Paciente\n3 - Internações" +
                    "\n4 - Triagem\n5 - Arquivados(Sem Covid)\n6 - Exames\n0 - Sair");
                selecao = Console.ReadLine();
                int.TryParse(selecao, out opcao);
                if ((opcao < 0) || (opcao > 6))
                {
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione ENTER para voltar...");
                    Console.ReadKey();
                }
                else
                {
                    flag = false;
                }
            } while (flag);


            return opcao;
        }

        static void Main(string[] args)
        {
            int opcao = 0;
            bool flag = true;

            opcao = MenuPrincipal();

            do
            {
                switch (opcao)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Entrada de Paciente");
                        break;
                    case 2:
                        Console.WriteLine("Buscar de Paciente");
                        break;
                    case 3:
                        Console.WriteLine("Internações");
                        break;
                    case 4:
                        Console.WriteLine("Triagem");
                        break;
                    case 5:
                        Console.WriteLine("Arquivados(Sem Covid)");
                        break;
                    case 6:
                        Console.WriteLine("Exames");
                        break;
                }
            } while (flag);
        }
    }
}
