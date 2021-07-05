using System.Collections.Generic;
using Vendas.Dados;

namespace Vendas.Model
{
    public class EstabelecimentoModelo
    {
        /// <summary>
        /// Metodo que cria um objeto do tipo estabelecimento e insere na lista, caso ele já não existir.
        /// </summary>
        /// <param name="listaEstabelecimentos">List<Estabelecimento></param>
        /// <param name="idEstabelecimento">int</param>
        /// <param name="nomeEstabelecimento">string</param>
        /// <param name="idEndereco">int</param>
        /// <returns>List<Estabelecimento></returns>
        public static List<Estabelecimento> AdicionaEstabelecimento(List<Estabelecimento> listaEstabelecimentos, int idEstabelecimento, string nomeEstabelecimento, int idEndereco)
        {
            if (listaEstabelecimentos.Count == 0) listaEstabelecimentos.Add(new Estabelecimento(idEstabelecimento, nomeEstabelecimento, idEndereco));
            else
            {
                if (!VerificaExistencia(listaEstabelecimentos, idEstabelecimento, nomeEstabelecimento, idEndereco))
                {
                    listaEstabelecimentos.Add(new Estabelecimento(idEstabelecimento, nomeEstabelecimento, idEndereco));
                }
            }

            return listaEstabelecimentos;
        }
        /// <summary>
        /// Faz a verificação se um objeto do tipo Estabelecimento se encontra dentro da lista.
        /// </summary>
        /// <param name="listaEstabelecimentos">List<Estabelecimento></param>
        /// <param name="idEstabelecimento">int</param>
        /// <param name="nomeEstabelecimento">string</param>
        /// <param name="idEndereco">int</param>
        /// <returns>bool</returns>
        public static bool VerificaExistencia(List<Estabelecimento> listaEstabelecimentos, int idEstabelecimento, string nomeEstabelecimento, int idEndereco)
        {
            foreach (Estabelecimento estabelecimentoDaLista in listaEstabelecimentos)
            {
                if (estabelecimentoDaLista.idEstabelecimento == idEstabelecimento && estabelecimentoDaLista.nomeEstabelecimento == nomeEstabelecimento
                    && estabelecimentoDaLista.idEndereco == idEndereco)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
