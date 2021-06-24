using System;

namespace Calculadora2_0
{
    class Calculadora2_0
    {
        public static string VerificaReuso(string operacao) {
         
            Console.WriteLine("Deseja fazer uma nova operação? 'sim' ou 'sair'");
            operacao = Console.ReadLine();
            return operacao;
        }

        static void Main(string[] args)
        { 
            double numero1;
            double numero2;
            string operacao;
            
            do
            {
                Console.WriteLine("Informe uma Operação (+ , - , / , *)");
                Console.WriteLine("Caso queira sair digite: 'sair'.");
                operacao = Console.ReadLine();
                if (operacao == "+")
                {
                    Console.WriteLine("Informe o valor do primeiro número:");
                    double.TryParse(Console.ReadLine(), out numero1);
                    Console.WriteLine("Informe o valor do segundo número:");
                    double.TryParse(Console.ReadLine(), out numero2);
                    Console.WriteLine(numero1 + " + " + numero2 + " = " + (numero1 + numero2));

                    operacao = VerificaReuso(operacao);

                }
                else if (operacao == "-")
                {
                    Console.WriteLine("Informe o valor do primeiro número:");
                    double.TryParse(Console.ReadLine(), out numero1);
                    Console.WriteLine("Informe o valor do segundo número:");
                    double.TryParse(Console.ReadLine(), out numero2);
                    Console.WriteLine(numero1 + " - " + numero2 + " = " + (numero1 - numero2));

                    operacao = VerificaReuso(operacao);
                }
                else if (operacao == "/")
                {
                    Console.WriteLine("Informe o valor do primeiro número:");
                    double.TryParse(Console.ReadLine(), out numero1);
                    Console.WriteLine("Informe o valor do segundo número:");
                    double.TryParse(Console.ReadLine(), out numero2);
                    if (numero2 != 0)
                    {
                        Console.WriteLine(numero1 + " / " + numero2 + " = " + (numero1 / numero2));
                    }
                    else
                    {
                        Console.WriteLine("Divisão por zero.");
                    }
                    operacao = VerificaReuso(operacao);
                }
                else if (operacao == "*")
                {
                    Console.WriteLine("Informe o valor do primeiro número:");
                    double.TryParse(Console.ReadLine(), out numero1);
                    Console.WriteLine("Informe o valor do segundo número:");
                    double.TryParse(Console.ReadLine(), out numero2);
                    Console.WriteLine(numero1 + " * " + numero2 + " = " + (numero1 * numero2));

                    operacao = VerificaReuso(operacao);
                }
                else
                {
                    if (operacao != "sair")
                    {
                        Console.Clear();
                        Console.WriteLine("Operação Invalida");  
                    }
                    
                }
                if (operacao == "sim")
                {
                    Console.Clear();
                    Console.WriteLine("Nova Operação:");
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Opção Invalida");
                }
            } while (operacao != "sair");
            
        }
    }
}
