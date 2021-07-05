using System;
using System.Collections.Generic;
using Vendas.Dados;

namespace Vendas.Model
{
    public class VendaModelo
    {
        /// <summary>
        /// Metodo que cria um objeto do tipo vendo e insere na lista, caso ele já não existir.
        /// </summary>
        /// <param name="listaVendas">List<Venda></param>
        /// <param name="idProduto">long</param>
        /// <param name="idEstabelecimento">int</param>
        /// <param name="codigoBarra">long</param>
        /// <param name="dataHora">DateTime</param>
        /// <param name="tipoPagamento">string</param>
        /// <param name="valor">double</param>
        /// <returns>List<Venda></returns>
        public static List<Venda> AdicionaVenda(List<Venda> listaVendas, long idProduto, int idEstabelecimento, long codigoBarra, DateTime dataHora, string tipoPagamento, double valor)
        {
            if (listaVendas.Count == 0) listaVendas.Add(new Venda(idProduto, idEstabelecimento, codigoBarra, dataHora, tipoPagamento, valor));
            else
            {
                if (!VerificaExistencia(listaVendas, idProduto, idEstabelecimento, codigoBarra, dataHora, tipoPagamento, valor))
                {
                    listaVendas.Add(new Venda(idProduto, idEstabelecimento, codigoBarra, dataHora, tipoPagamento, valor));
                }
            }

            return listaVendas;
        }

        /// <summary>
        /// Faz a verificação se um objeto do tipo Venda se encontra dentro da lista.
        /// </summary>
        /// <param name="listaVendas">List<Venda></param>
        /// <param name="idProduto">long</param>
        /// <param name="idEstabelecimento">int</param>
        /// <param name="codigoBarra">long</param>
        /// <param name="dataHora">DateTime</param>
        /// <param name="tipoPagamento">string</param>
        /// <param name="valor">double</param>
        /// <returns>bool</returns>
        private static bool VerificaExistencia(List<Venda> listaVendas, long idProduto, int idEstabelecimento, long codigoBarra, DateTime dataHora, string tipoPagamento, double valor)
        {
            foreach (Venda vendaDaLista in listaVendas)
            {
                if (vendaDaLista.idProduto == idProduto && vendaDaLista.idEstabelecimento == idEstabelecimento && vendaDaLista.codigoBarra == codigoBarra
                    && vendaDaLista.dataHora == dataHora && vendaDaLista.tipoPagamento == tipoPagamento && vendaDaLista.valor == valor)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
