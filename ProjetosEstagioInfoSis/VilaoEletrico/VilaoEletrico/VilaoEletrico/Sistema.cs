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
            this.LePIS();

            Console.Clear();
            Console.WriteLine("Cadastrando Dados do Sistema:\n");
            this.ImprimeDados();
            this.LeCOFINS();

            Console.Clear();
            Console.WriteLine("Cadastrando Dados do Sistema:\n");
            this.ImprimeDados();
            this.LeICMS();

            Console.Clear();
            this.ImprimeDados();
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
            Console.WriteLine("Digite a cor da bandeira: ('verde','amarela','vermelha p1', 'vermelha p2')");
            string op;
            
            do
            {
                op = Console.ReadLine().ToLower();
                switch (op) 
                {
                    case "verde":
                        this.bandeira = op;
                        break;
                    case "amarela":
                        this.bandeira = op;
                        break;
                    case "vermelha p1":
                        this.bandeira = op;
                        break;
                    case "vermelha p2":
                        this.bandeira = op;
                        break;
                    default:
                        Console.Clear();
                        this.ImprimeDados();
                        Console.WriteLine("Não existe bandeira '"+op+"'");
                        Console.WriteLine("Digite uma bandeira válida: ('verde','amarela','vermelha p1', 'vermelha p2')");
                        break;
                }
            }while (op != "verde" && op != "amarela" && op != "vermelha p1" && op != "vermelha p2");
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
            Console.WriteLine("Cadastrando Itens:\n");

            do
            {
                if (listaItens.Count > 0) Console.WriteLine("\nDeseja cadastrar um novo item? 's' ou 'n'");
                else Console.WriteLine("Deseja cadastrar um item? 's' ou 'n'"); 
                
                op = Console.ReadLine().ToLower();
                switch (op)
                {
                    case "s":
                        Console.Clear();
                        Console.WriteLine("----Novo Item----\n");
                        
                        Item item = new Item();
                        item.PreencherItem();
                        listaItens.Add(item);
                        
                        Console.WriteLine("Item Cadastrado.\n");
                        item.ImprimeItem();
                        break;
                    case "n":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Não existe opção '" + op + "'");
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

            if (this.listaItens.Count > 0)
            {
                //Ordenação da lista para obter o primeiro e ultimo
                listaItens.Sort(new OrdernarItemPorUso());

                Console.WriteLine("ITEM QUE TEVE MAIOR USO: \n");
                listaItens[listaItens.Count - 1].ImprimeItem();

                Console.WriteLine("\n------------------------------------------------------------------------\n");

                Console.WriteLine("ITEM QUE TEVE MENOR USO: \n");
                listaItens[0].ImprimeItem();

                Console.WriteLine("\n------------------------------------------------------------------------\n");

                Console.WriteLine("ITEM QUE TEVE MAIOR GASTO: \n");

                this.ImprimeMaiorGasto();

                Console.WriteLine("\n------------------------------------------------------------------------\n");

                Console.WriteLine("ITEM QUE TEVE MENOR GASTO: \n");

                this.ImprimeMenorGasto();

                Console.WriteLine("\n------------------------------------------------------------------------\n");

                Console.WriteLine("LISTA DE PRODUTOS: \n");

                this.ImprimeItens();

                Console.WriteLine("------------------------------------------------------------------------\n");

                this.ImprimeValorDaConta();

            }
            else
            {
                this.ImprimeValorDaConta();
            }
        }

        /// <summary>
        /// Metodo que determina e imprime o Item que teve o maior gasto
        /// </summary>
        private void ImprimeMaiorGasto()
        {
            Item maior = listaItens[0];
            
            foreach (Item i in listaItens)
            {

                if (this.CalculaValorConsumo(i) > this.CalculaValorConsumo(maior)) maior = i;

            }
            maior.ImprimeItem();
            Console.WriteLine("Valor do consumo do item: " + this.CalculaValorConsumo(maior).ToString("C") + "\n");
        }


        /// <summary>
        /// Metodo que determina e imprime o Item que teve o menor gasto
        /// </summary>
        private void ImprimeMenorGasto()
        {
            Item menor = listaItens[0];

            foreach (Item i in listaItens)
            {
                if (this.CalculaValorConsumo(i) < this.CalculaValorConsumo(menor)) menor = i;
            }
            menor.ImprimeItem();
            Console.WriteLine("Valor do item: " + this.CalculaValorConsumo(menor).ToString("C") + "\n");
        }

        /// <summary>
        /// Imprime a lista de itens com o valor a pagar pelo seu consumo
        /// </summary>
        public void ImprimeItens() 
        {
            foreach (Item i in listaItens)
            {
                i.ImprimeItem();
                Console.WriteLine("Valor: " + this.CalculaValorConsumo(i).ToString("C") + "\n");
            }
        }

        /// <summary>
        /// Metodo que efetua o calcula do valor a se pagar para um determinado item
        /// </summary>
        /// <param name="i">Item</param>
        /// <returns>double</returns>
        public double CalculaValorConsumo(Item i) 
        {
            double valor = ((i.GetConsumo() * i.GetUsoPorMeS()) / 1000) * this.valorTarifa;
            double total = Math.Round(valor,2);

            return total;
        }

        /// <summary>
        /// Calcula e Imprime o valor das taxas e da conta;
        /// </summary>
        /// <param name="i">Item</param>
        public void ImprimeValorDaConta() 
        {
            double consumo = 0;
            double taxaPIS = 0;
            double taxaCOFINS = 0;
            double taxaICMS = 0;

            foreach (Item i in listaItens) 
            {
                consumo += this.CalculaValorConsumo(i);
            }

            if (consumo == 0)
            {
                consumo = 37.50;
                Console.WriteLine("Taxa de Disponibilidade: " + Math.Round(consumo, 2).ToString("C") + "\n");
            }
            else
            {
                Console.WriteLine("Valor sem Taxa: " + Math.Round(consumo, 2).ToString("C") + "\n");
            }

            Console.WriteLine("-----TRIBUTOS-----");
            taxaPIS = Math.Round(consumo * (this.pis / 100),2);
            Console.WriteLine("Taxa PIS: " + Math.Round(taxaPIS,2).ToString("C"));

            taxaCOFINS = Math.Round(consumo * (this.cofins / 100),2);
            Console.WriteLine("Taxa COFINS: " + Math.Round(taxaCOFINS,2).ToString("C"));

            taxaICMS = Math.Round((consumo + taxaPIS + taxaCOFINS) * (this.icms / 100),2);
            Console.WriteLine("Taxa ICMS: " + Math.Round(taxaICMS, 2).ToString("C"));

            Console.WriteLine("\n------------------------------------------------------------------------\n");
            Console.WriteLine("Valor total da conta: "+ (consumo+taxaPIS+taxaCOFINS+taxaICMS).ToString("C"));
        }


        /// <summary>
        /// Metodo que imprime os dados do Sistema
        /// </summary>
        public void ImprimeDados() 
        {
            Console.WriteLine("Valor da Tarifa: R$ " + this.valorTarifa.ToString("F8") + " por Kw/h");
            Console.WriteLine("Bandeira: " + this.bandeira);
            Console.WriteLine("PIS: "+this.pis.ToString("F2") + " %");
            Console.WriteLine("COFINS: "+this.cofins.ToString("F2")+ " %");
            Console.WriteLine("ICMS: " + this.icms.ToString("F2") + " %" + "\n");
        }


    }
}
