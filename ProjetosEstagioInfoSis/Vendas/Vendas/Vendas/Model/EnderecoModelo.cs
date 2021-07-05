using System.Collections.Generic;
using Vendas.Dados;

namespace Vendas.Model
{
    public class EnderecoModelo
    {
        /// <summary>
        /// Metodo que cria um objeto do tipo endereco e insere na lista, caso ele já não existir.
        /// </summary>
        /// <param name="listaEnderecos">List<Endereco></param>
        /// <param name="id">int</param>
        /// <param name="logradouro">string</param>
        /// <param name="numeroLogradouro">string</param>
        /// <param name="complemento">string</param>
        /// <param name="bairro">string</param>
        /// <param name="codigoMunicipioIBGE">int</param>
        /// <param name="municipio">string</param>
        /// <param name="estado">string</param>
        /// <param name="cep">int</param>
        /// <param name="latitude">double</param>
        /// <param name="longitude">double</param>
        /// <returns>List<Endereco></returns>
        public static List<Endereco> AdicionaEndereco(List<Endereco> listaEnderecos, int id, string logradouro, string numeroLogradouro, string complemento, string bairro, int codigoMunicipioIBGE,
        string municipio, string estado, int cep, double latitude, double longitude)

        {
            if (listaEnderecos.Count == 0) listaEnderecos.Add(new Endereco(id, logradouro, numeroLogradouro, complemento, bairro, codigoMunicipioIBGE,
                                                                             municipio, estado, cep, latitude, longitude));
            else
            {
                if (!VerificaExistencia(listaEnderecos, logradouro, numeroLogradouro, complemento, bairro, codigoMunicipioIBGE,
                                        municipio, estado, cep, latitude, longitude))
                {
                    listaEnderecos.Add(new Endereco(id, logradouro, numeroLogradouro, complemento, bairro, codigoMunicipioIBGE,
                                                    municipio, estado, cep, latitude, longitude));
                }
            }

            return listaEnderecos;
        }

        /// <summary>
        /// Faz a verificação se um objeto do tipo Endereco se encontra dentro da lista.
        /// </summary>
        /// <param name="listaEnderecos">List<Endereco></param>
        /// <param name="logradouro">string</param>
        /// <param name="numeroLogradouro">string</param>
        /// <param name="complemento">string</param>
        /// <param name="bairro">string</param>
        /// <param name="codigoMunicipioIBGE">int</param>
        /// <param name="municipio">string</param>
        /// <param name="estado">string</param>
        /// <param name="cep">int</param>
        /// <param name="latitude">double</param>
        /// <param name="longitude">double</param>
        /// <returns></returns>
        public static bool VerificaExistencia(List<Endereco> listaEnderecos, string logradouro, string numeroLogradouro, string complemento, string bairro, int codigoMunicipioIBGE,
        string municipio, string estado, int cep, double latitude, double longitude)
        {
            foreach (Endereco enderecoDaLista in listaEnderecos)
            {
                if (enderecoDaLista.logradouro == logradouro && enderecoDaLista.numeroLogradouro == numeroLogradouro
                    && enderecoDaLista.complemento == complemento && enderecoDaLista.bairro == bairro
                    && enderecoDaLista.codigoMunicipioIBGE == codigoMunicipioIBGE && enderecoDaLista.municipio == municipio
                    && enderecoDaLista.estado == estado && enderecoDaLista.cep == cep
                    && enderecoDaLista.latitude == latitude && enderecoDaLista.longitude == longitude)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Faz a busca de um endereco dentro da lista e retorna o ID desse endereco, retorna 0 caso nao encontre
        /// </summary>
        /// <param name="listaEnderecos">List<Endereco></param>
        /// <param name="logradouro">string</param>
        /// <param name="numeroLogradouro">string</param>
        /// <param name="complemento">string</param>
        /// <param name="bairro">string</param>
        /// <param name="codigoMunicipioIBGE">int</param>
        /// <param name="municipio">string</param>
        /// <param name="estado">string</param>
        /// <param name="cep">int</param>
        /// <param name="latitude">double</param>
        /// <param name="longitude">double</param>
        /// <returns>int</returns>
        public static int GetIdEndereco(List<Endereco> listaEnderecos, string logradouro, string numeroLogradouro, string complemento, string bairro, int codigoMunicipioIBGE,
        string municipio, string estado, int cep, double latitude, double longitude)
        {
            foreach (Endereco enderecoDaLista in listaEnderecos)
            {
                if (enderecoDaLista.logradouro == logradouro && enderecoDaLista.numeroLogradouro == numeroLogradouro
                    && enderecoDaLista.complemento == complemento && enderecoDaLista.bairro == bairro
                    && enderecoDaLista.codigoMunicipioIBGE == codigoMunicipioIBGE && enderecoDaLista.municipio == municipio
                    && enderecoDaLista.estado == estado && enderecoDaLista.cep == cep
                    && enderecoDaLista.latitude == latitude && enderecoDaLista.longitude == longitude)
                {
                    return enderecoDaLista.id;
                }
            }
            return 0;
        }
    }
}
