using System;
using System.Collections.Generic;
using System.IO;
using Vendas.Dados;
using Vendas.Model;
using Vendas.Servicos;

namespace Vendas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> listaLinhas = new List<string>();

            List<Endereco> listaEnderecos = new List<Endereco>();
            List<Estabelecimento> listaEstabelecimentos = new List<Estabelecimento>();
            List<Produto> listaProdutos = new List<Produto>();
            List<Venda> listaVendas = new List<Venda>();

            listaLinhas = LeituraCSV.LeCSV(listaLinhas);
            
            foreach (string linha in listaLinhas)
            {
                var campo = linha.Split(',');
                int idEndereco;

                if(campo[18] == "" && campo[19] == "") 
                {
                    listaEnderecos = EnderecoModelo.AdicionaEndereco(listaEnderecos, listaEnderecos.Count + 1, campo[10], campo[11], campo[12], campo[13], 
                        int.Parse(campo[14]), campo[15], campo[16], int.Parse(campo[17]),0,0);
                    
                    idEndereco = EnderecoModelo.GetIdEndereco(listaEnderecos, campo[10], campo[11], campo[12], campo[13],
                        int.Parse(campo[14]), campo[15], campo[16], int.Parse(campo[17]), 0, 0);
                }
                else 
                {
                    listaEnderecos = EnderecoModelo.AdicionaEndereco(listaEnderecos, listaEnderecos.Count + 1, campo[10], campo[11], campo[12], campo[13], 
                        int.Parse(campo[14]), campo[15], campo[16], int.Parse(campo[17]), double.Parse(campo[18]), double.Parse(campo[19]));
                    
                    idEndereco = EnderecoModelo.GetIdEndereco(listaEnderecos, campo[10], campo[11], campo[12], campo[13],
                        int.Parse(campo[14]), campo[15], campo[16], int.Parse(campo[17]), double.Parse(campo[18]), double.Parse(campo[19]));
                }

                listaEstabelecimentos = EstabelecimentoModelo.AdicionaEstabelecimento(listaEstabelecimentos, int.Parse(campo[8]), campo[9], idEndereco);

                listaProdutos = ProdutoModelo.AdicionaProduto(listaProdutos, long.Parse(campo[0]), long.Parse(campo[3]), int.Parse(campo[4]), campo[5], campo[6], double.Parse("0"+campo[7])/100, int.Parse(campo[8]));

                listaVendas = VendaModelo.AdicionaVenda(listaVendas, long.Parse(campo[3]), int.Parse(campo[8]), long.Parse(campo[3]), DateTime.Parse(campo[1]), campo[1], double.Parse("0" + campo[7]) / 100);

            }
            
            Console.WriteLine("Linhas Lidas: " + listaLinhas.Count);
            Console.WriteLine("Enderecos Lidos: " + listaEnderecos.Count);
            Console.WriteLine("Estabelecimentos Lidos: " + listaEstabelecimentos.Count);
            Console.WriteLine("Produtos Lidos: " + listaProdutos.Count);
            Console.WriteLine("Vendas Lidas: " + listaVendas.Count);
            Console.ReadLine();
        }
    }
}
