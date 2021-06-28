using System;

namespace VilaoEletrico
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();
            
            sistema.CadastrarValoresDoSistema();
            sistema.ImprimeDados();
            sistema.CadastrarItens();
            sistema.ImprimeRelatorio();
        }
    }
}