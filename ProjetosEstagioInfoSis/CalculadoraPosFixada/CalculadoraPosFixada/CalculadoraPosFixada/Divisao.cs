using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraPosFixada
{
    public class Divisao
    {
        /// <summary>
        /// Metodo que efetua a divisão entre 2 valores desde que o segundo seja diferente de zero, caso contrario sera retornado o valor do primeiro valor.
        /// </summary>
        /// <param name="a">double</param>
        /// <param name="b">double</param>
        /// <returns>double</returns>
        public static double DivideNumeros(double a, double b) 
        {
            //Caso seja feito uma divisão por zero retorna apenas o valor de a.
            if (b != 0) return a / b;
            Console.WriteLine("\nDivisão por Zero programa Abortado");
            System.Environment.Exit(0);
            return a/b;
        }
    }
}
