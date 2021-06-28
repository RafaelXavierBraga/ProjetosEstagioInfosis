using System;
using System.Collections.Generic;
using System.Text;

namespace VilaoEletrico
{
    public class Sistema
    {
        private double valorTarifa;   
        private string bandeira;       
        private double icms;           
        private double pis;            
        private double cofins;         
        private List<Item> listaItens;

        public Sistema()
        {
            this.listaItens = new List<Item>();
        }
        
        
        /// <summary>
        /// Metodo que faz o cadastro dos dados do Sistema
        /// </summary>
        public void CadastrarValoresDoSistema() 
        {
            Console.WriteLine("Cadastrando Dados do Sistema:\n");
            this.ImprimeDados();
            this.LeValorTarifa();
            
            Console.Clear();
            Console.WriteLine("Cadastrando Dados do Sistema:\n");
            this.ImprimeDados();
            this.LeBandeira();

            Console.Clear();
            Console.WriteLine("Cadastrando Dados do Sistema:\n");
            this.ImprimeDados();
            this.LeICMS();

            Console.Clear();
            Console.WriteLine("Cadastrando Dados do Sistema:\n");
            this.ImprimeDados();
            this.LePIS();

            Console.Clear();
            Console.WriteLine("Cadastrando Dados do Sistema:\n");
            this.ImprimeDados();
            this.LeCOFINS();

            Console.Clear();

        }

        /// <summary>
        /// Metodo que le o valor da tarifa do KW/h
        /// </summary>
        public void LeValorTarifa() 
        {
            string valor;
            Console.WriteLine("Digite o valor da tarifa do Kw/h:");
            valor = Console.ReadLine();
            do
            {
                if (!double.TryParse(valor, out this.valorTarifa))
                {
                    Console.Clear();
                    valor = Console.ReadLine();
                }
            } while (!double.TryParse(valor, out this.valorTarifa));
        }

        /// <summary>
        /// Metodo que le a cor bandeira
        /// </summary>
        private void LeBandeira()
        {
            Console.WriteLine("Digite a cor da bandeira: ('verde','amarela','vermelha')");
            string op;

            op = Console.ReadLine();
            this.bandeira = op;

        }

        /// <summary>
        /// Metodo que le o valor do ICMS
        /// </summary>
        private void LeICMS()
        {
            string valor;
            Console.WriteLine("Digite o valor do ICMS em %:");
            valor = Console.ReadLine();
            do
            {
                if (!double.TryParse(valor, out this.icms))
                {
                    Console.Clear();
                    valor = Console.ReadLine();
                }

            } while (!double.TryParse(valor, out this.icms));
        }

        /// <summary>
        /// Metodo que le o valor do PIS
        /// </summary>
        private void LePIS()
        {
            string valor;
            Console.WriteLine("Digite o valor do PIS em %:");
            valor = Console.ReadLine();
            do
            {
                if (!double.TryParse(valor, out this.pis))
                {
                    Console.Clear();
                    valor = Console.ReadLine();
                }
            } while (!double.TryParse(valor, out this.pis));
        }

        /// <summary>
        /// Metodo que le o valor do COFINS
        /// </summary>
        private void LeCOFINS()
        {
            string valor;
            Console.WriteLine("Digite o valor do COFINS em %:");
            valor = Console.ReadLine();
            do
            {
                if (!double.TryParse(valor, out this.cofins))
                {
                    Console.Clear();
                    valor = Console.ReadLine();
                }
            } while (!double.TryParse(valor, out this.cofins));
        }

        /// <summary>
        /// Metodo que cadastra n itens e insere na lista
        /// </summary>
        public void CadastrarItens()
        {
            string op;
            Console.WriteLine("Cadastrando Itens:");

            do
            {
                Console.WriteLine("\nDeseja cadastrar um novo item? 's' ou 'n'");
                op = Console.ReadLine();
                switch (op)
                {
                    case "s":
                        Console.Clear();
                        Console.WriteLine("Novo Item:\n");
                        
                        Item item = new Item();
                        item.PreencherItem();
                        listaItens.Add(item);
                        
                        Console.WriteLine("Item Cadastrado.");
                        item.ImprimeItem();
                        break;
                    case "n":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opcao Invalida");
                        break;
                }
            } while (op != "n");  
        }

        /// <summary>
        /// Metodo que imprime o Relatorio da conta de luz
        /// </summary>
        public void ImprimeRelatorio() 
        {
            Console.WriteLine("------------------------------CONTA DE LUZ------------------------------\n");
            this.ImprimeDados();
            Console.WriteLine("------------------------------------------------------------------------\n");

            if (this.listaItens.Count < 1) Console.WriteLine("Não houve Itens Cadastrados.");
            else
            {
                //Ordenação da lista para obter o primeiro e ultimo
                listaItens.Sort(new OrdernarItemPorUso());
                Console.WriteLine("ITEM QUE TEVE MAIOR USO: \n");
                listaItens[listaItens.Count-1].ImprimeItem();
                Console.WriteLine("Uso: "+ listaItens[listaItens.Count - 1].GetTempoDeUso()*30 + " horas");

                Console.WriteLine("\n------------------------------------------------------------------------\n");

                Console.WriteLine("ITEM QUE TEVE MENOR USO: \n");

                listaItens[0].ImprimeItem();
                Console.WriteLine("Uso: " + listaItens[0].GetTempoDeUso() * 30 + " horas");

                Console.WriteLine("\n------------------------------------------------------------------------\n");

                Console.WriteLine("ITEM QUE TEVE MAIOR GASTO: \n");

                this.ImprimeMaiorGasto();

                Console.WriteLine("\n------------------------------------------------------------------------\n");

                Console.WriteLine("ITEM QUE TEVE MENOR GASTO: \n");

                this.ImprimeMenorGasto();

                Console.WriteLine("\n------------------------------------------------------------------------\n");

                Console.WriteLine("LISTA DE PRODUTOS: \n");

                this.ImprimeValorConta();
                
            }

        }

        /// <summary>
        /// Metodo que imprime o Item que teve o maior gasto
        /// </summary>
        private void ImprimeMaiorGasto()
        {
            Item maior = listaItens[0];
            
            foreach (Item i in listaItens)
            {

                if (this.CalculaValor(i) > this.CalculaValor(maior)) maior = i;

            }
            maior.ImprimeItem();
            Console.WriteLine("Valor do item: " + this.CalculaValor(maior).ToString("C") + "\n");
        }


        /// <summary>
        /// Metodo que imprime o Item que teve o menor gasto
        /// </summary>
        private void ImprimeMenorGasto()
        {
            Item menor = listaItens[0];

            foreach (Item i in listaItens)
            {
                if (this.CalculaValor(i) < this.CalculaValor(menor)) menor = i;
            }
            menor.ImprimeItem();
            Console.WriteLine("Valor do item: " + this.CalculaValor(menor).ToString("C") + "\n");
        }

        /// <summary>
        /// Imprime a lista de itens com seu tempo de uso e valores, junto da soma total dos valores
        /// </summary>
        public void ImprimeValorConta() 
        {
            double total = 0;
            
            foreach (Item i in listaItens)
            {
                i.ImprimeItem();
                Console.WriteLine("Uso: " + i.GetTempoDeUso() * 30 + " horas");
                this.ImprimeTaxa(i);
                Console.WriteLine("Valor: " + this.CalculaValor(i).ToString("C") + "\n");
                total += this.CalculaValor(i);
            }
            Console.WriteLine("------------------------------------------------------------------------\n");
            Console.WriteLine("Valor total da conta: "+ total.ToString("C"));
        }

        /// <summary>
        /// Metodo que efetua o calcula do valor a se pagar para um determinado item, considerando impostos.
        /// </summary>
        /// <param name="i">Item</param>
        /// <returns>double</returns>
        public double CalculaValor(Item i) 
        {
            double valor = ((i.GetConsumo() * 30 * i.GetTempoDeUso()) / 1000) * this.valorTarifa;
            double total = Math.Round(valor,2);

            total += Math.Round(valor * (this.icms / 100),2);

            total += Math.Round(valor * (this.pis / 100),2);

            total += Math.Round(valor * (this.cofins / 100),2);

            return total;
        }

        /// <summary>
        /// Imprime o valor das taxas sobre um item;
        /// </summary>
        /// <param name="i">Item</param>
        public void ImprimeTaxa(Item i) 
        {
            double valor = ((i.GetConsumo() * 30 * i.GetTempoDeUso()) / 1000) * this.valorTarifa;
            
            Console.WriteLine("Valor sem Taxa: " + Math.Round(valor,2).ToString("C"));

            Console.WriteLine("Taxa ICMS: " + Math.Round((valor * (this.icms / 100)),2).ToString("C"));

            Console.WriteLine("Taxa PIS: " + Math.Round((valor * (this.pis / 100)),2).ToString("C"));

            Console.WriteLine("Taxa COFINS: " + Math.Round((valor * (this.cofins / 100)),2).ToString("C"));
        }


        /// <summary>
        /// Metodo que imprime os dados do Sistema
        /// </summary>
        public void ImprimeDados() 
        {
            Console.WriteLine("Valor da Tarifa: " + this.valorTarifa.ToString("C") + " por Kw/h");
            Console.WriteLine("Bandeira: " + this.bandeira);
            Console.WriteLine("ICMS: "+ this.icms +" %");
            Console.WriteLine("PIS: "+this.pis +" %");
            Console.WriteLine("COFINS: "+this.cofins+ " %" +"\n");
        }


    }
}
