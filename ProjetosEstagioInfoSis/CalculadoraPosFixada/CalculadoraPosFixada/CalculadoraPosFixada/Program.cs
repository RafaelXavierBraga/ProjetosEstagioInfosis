using System;
using System.Collections.Generic;

namespace CalculadoraPosFixada
{
    class Program
    {
        /// <summary>
        /// Metodo que faz leitura dos numeros e adiciona em uma lista ate que seja digitado 'p' , qualquer valor digitado nao numerico é ignorado e não adicionado a Lista.
        /// </summary>
        /// <param name="lista">List<double></param>
        /// <returns>List<double></returns>
        public static List<double> LeNumeros(List<double> lista) 
        {
            double numero;
            string op = "s";

            Console.WriteLine("Digite os números que deseja, 1 por vez.");
            Console.WriteLine("Para parar de digitar os numeros, digite 'p'.");
            
            do
            {
                op = Console.ReadLine();

                if (op != "p") 
                {
                    if (double.TryParse(op, out numero))
                    {
                        Console.WriteLine("Numero Valido");
                        lista.Add(numero);
                    }
                    else
                    {
                        Console.WriteLine("Valor Invalido");
                    }
                }

            } while (op != "p");
                
            
            return lista;
        }

        /// <summary>
        /// Efetua a leitura das operações entre as possiveis, retornando uma lista com essa operações de tamanho nElementos - 1.
        /// </summary>
        /// <param name="lista">List<char></param>
        /// <param name="contador">int</param>
        /// <returns>List<char></returns>
        public static List<char> LeOperacoes(List<char> lista, int nElementos)
        {
            int cont = 1;
            string op = "s";
            char operacao;
            if (nElementos > 1)
            {
                Console.WriteLine("Digite as operaçoes a serem efetuadas (+ , - , / , *) uma por vez.");

                while (cont < nElementos)
                {
                    op = Console.ReadLine();

                    //Se o valor lido for um char
                    if (char.TryParse(op, out operacao))
                    {
                        //Se o char lido for 1 valido
                        if (operacao == '+' || operacao == '-' || operacao == '*' || operacao == '/')
                        {
                            Console.WriteLine("Operacao Valida");
                            lista.Add(operacao);
                            cont++;
                        }
                        else
                        {
                            Console.WriteLine("Valor Invalido");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Valor Invalido");
                    }

                }
            }
            

            return lista;
        }

        /// <summary>
        /// Metodo que efetua o calcula dado a lista de valores e operações, imprimindo os numeros e operações que foram sendo efetuados junto com o resultado.
        /// </summary>
        /// <param name="listaNumeros">List<double></param>
        /// <param name="listaOperacoes">List<char></param>
        public static void EfetuaCalculo(List<double> listaNumeros, List<char> listaOperacoes) 
        {
            double total = listaNumeros[0];

            Console.Write(listaNumeros[0]);
            //Efetua os calculos e print das operações
            for (int i = 0; i < listaOperacoes.Count; i++ ) 
            {
                if (listaOperacoes[i] == '+')
                {
                    total = Soma.SomaNumeros(total, listaNumeros[i+1]);
                }
                else if (listaOperacoes[i] == '/')
                {
                    total = Divisao.DivideNumeros(total, listaNumeros[i + 1]);
                }
                else if (listaOperacoes[i] == '-')
                {
                    total = Subtracao.SubtraiNumeros(total, listaNumeros[i + 1]);
                }
                else
                {
                    total = Multiplicacao.MultiplicaNumeros(total, listaNumeros[i + 1]);
                }
                
                Console.Write(" " + listaOperacoes[i] + " ");
                Console.Write(listaNumeros[i+1]);
            }
            Console.WriteLine(" = "+ total);
        }

        public static void Main(string[] args)
        {
            List<double> numeros = new List<double>();
            List<char> operacoes = new List<char>();
            string opcao = "s";
            
            do {
                numeros.Clear();
                operacoes.Clear();

                numeros = LeNumeros(numeros);
                Console.Clear();
                operacoes = LeOperacoes(operacoes, numeros.Count);
                Console.Clear();


                EfetuaCalculo(numeros, operacoes);

                Console.WriteLine("Deseja efetuar uma nova conta? 's' ou 'n'");
                opcao = Console.ReadLine();
                Console.Clear();
                //Verificao se a opcao digitada foi valida
                if (opcao != "s" && opcao != "n") 
                {
                    Console.Clear();
                    Console.WriteLine("Opcao Invalida");
                }
            } while (opcao != "n");
            
        }
    }
}
