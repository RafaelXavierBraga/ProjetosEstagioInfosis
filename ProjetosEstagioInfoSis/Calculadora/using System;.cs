using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Informe uma Operação +,-,/,*");
            string operacao = Console.ReadLine();
            double numero1;
            double numero2;
            
            if(operacao == "+"){
                Console.WriteLine("Informe o valor do primeiro número:");
                double.TryParse(Console.ReadLine,out numero1);
                Console.WriteLine("Informe o valor do segundo número:");
                double.TryParse(Console.ReadLine,out numero2);
                Console.WriteLine(numero1 +" + "+ numero2 + " = " + (numero1+numero2));

            }
            else if(operacao == "-"){
                Console.WriteLine("Informe o valor do primeiro número:");
                double.TryParse(Console.ReadLine,out numero1);
                Console.WriteLine("Informe o valor do segundo número:");
                double.TryParse(Console.ReadLine,out numero2);
                Console.WriteLine(numero1 +" - "+ numero2 + " = " + (numero1-numero2));
            }
            else if(operacao == "/"){
                Console.WriteLine("Informe o valor do primeiro número:");
                double.TryParse(Console.ReadLine,out numero1);
                Console.WriteLine("Informe o valor do segundo número:");
                double.TryParse(Console.ReadLine,out numero2);
                if(numero2 != 0){
                    Console.WriteLine(numero1 +" / "+ numero2 + " = " + (numero1/numero2));
                }
                else{
                    Console.WriteLine("Divisão por zero.");
                }
                
            }
            else if(operacao == "*"){
                Console.WriteLine("Informe o valor do primeiro número:");
                double.TryParse(Console.ReadLine,out numero1);
                Console.WriteLine("Informe o valor do segundo número:");
                double.TryParse(Console.ReadLine,out numero2);
                Console.WriteLine(numero1 +" * "+ numero2  +" = "+ (numero1*numero2));
            }
            else{
                Console.WriteLine("Operação Invalida");
                Console.WriteLine("Soma = ");
            }
        }
    }
}