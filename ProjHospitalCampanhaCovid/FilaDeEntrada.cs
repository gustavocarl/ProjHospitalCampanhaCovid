using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class FilaDeEntrada
    {
        #region Atributos/Propriedades da Fila de Entrada

        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }
        public int GerarSenha { get; set; }

        #endregion

        #region Construtor

        public FilaDeEntrada()
        {
            Head = null;
            Tail = null;
        }

        #endregion

        #region Métodos da Fila de Entrada

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
            novoPaciente.Senha = GerarSenha;
            GerarSenha++;
        }

        public void ImprimirFilaDeEntrada()
        {
            if (Vazio())
            {
                Console.WriteLine("Fila de Entrada Vazia");
                Console.WriteLine("Pressione ENTER para continuar...");
            }
            else
            {
                Paciente aux = Head;
                do
                {
                    Console.WriteLine(aux.Senha);
                    aux = aux.Proximo;
                } while (aux != null);
            }
            Console.ReadKey();
        }

        public void PuxarPaciente()
        {
            if (Vazio())
            {
                Console.WriteLine("Esta Fila está Vazia");
            }
            else
            {
                Console.WriteLine($"Senha: {Head.Senha + 1}");
                if (Head.Proximo == null)
                {
                    Tail = null;
                }
                Head = Head.Proximo;
            }
            Console.ReadKey();
        }

        public void Saida(int senha)
        {
            Paciente aux = Head;
            Paciente aux1 = Head.Proximo;
            if (aux.Senha == senha)
            {
                Head = Head.Proximo;
            }
            else
            {
                for (int i = 0; i < GerarSenha; i++)
                {
                    if (senha == aux1.Senha)
                    {
                        aux.Proximo = aux1.Proximo;
                        if (aux1.Proximo == null)
                        {
                            Tail = aux;
                        }
                    }
                    else
                    {
                        aux = aux1;
                        aux1 = aux1.Proximo;
                    }
                }
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
