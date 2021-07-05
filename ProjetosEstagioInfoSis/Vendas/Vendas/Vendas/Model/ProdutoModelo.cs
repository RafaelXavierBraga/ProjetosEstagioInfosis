using System.Collections.Generic;
using Vendas.Dados;

namespace Vendas.Model
{
    class ProdutoModelo
    {
        /// <summary>
        /// Metodo que cria um objeto do tipo produto e insere na lista, caso ele já não existir.
        /// </summary>
        /// <param name="listaProdutos">List<Produto></param>
        /// <param name="codigoBarra">long</param>
        /// <param name="idProduto">long</param>
        /// <param name="idNCM">int</param>
        /// <param name="tipoUnidade">string</param>
        /// <param name="descricaoProduto">string</param>
        /// <param name="valor">double</param>
        /// <param name="idEstabelecimento">int</param>
        /// <returns>List<Produto></returns>
        public static List<Produto> AdicionaProduto(List<Produto> listaProdutos, long codigoBarra, long idProduto, int idNCM, string tipoUnidade,
            string descricaoProduto, double valor, int idEstabelecimento)
        {
            if (listaProdutos.Count == 0) listaProdutos.Add(new Produto(codigoBarra, idProduto, idNCM, tipoUnidade, descricaoProduto, valor, idEstabelecimento));
            else
            {
                if (!VerificaExistencia(listaProdutos, codigoBarra, idProduto, idNCM, tipoUnidade, descricaoProduto, valor, idEstabelecimento))
                {
                    listaProdutos.Add(new Produto(codigoBarra, idProduto, idNCM, tipoUnidade, descricaoProduto, valor, idEstabelecimento));
                }
            }


            return listaProdutos;
        }

        /// <summary>
        /// Faz a verificação se um objeto do tipo Produto se encontra dentro da lista.
        /// </summary>
        /// <param name="listaProdutos">List<Produto></param>
        /// <param name="codigoBarra">long</param>
        /// <param name="idProduto">long</param>
        /// <param name="idNCM">int</param>
        /// <param name="tipoUnidade">string</param>
        /// <param name="descricaoProduto">string</param>
        /// <param name="valor">double</param>
        /// <param name="idEstabelecimento">int</param>
        /// <returns>bool</returns>
        private static bool VerificaExistencia(List<Produto> listaProdutos, long codigoBarra, long idProduto, int idNCM, string tipoUnidade, string descricaoProduto, double valor, int idEstabelecimento)
        {
            foreach (Produto produtoDaLista in listaProdutos)
            {
                if (produtoDaLista.codigoBarra == codigoBarra && produtoDaLista.idProduto == idProduto && produtoDaLista.idNCM == idNCM && produtoDaLista.tipoUnidade == tipoUnidade
                    && produtoDaLista.descricaoProduto == descricaoProduto && produtoDaLista.valor == valor && produtoDaLista.idEstabelecimento == idEstabelecimento)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
