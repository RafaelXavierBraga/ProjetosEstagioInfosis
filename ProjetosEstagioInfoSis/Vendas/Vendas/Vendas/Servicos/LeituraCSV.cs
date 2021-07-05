using System.Collections.Generic;
using System.IO;

namespace Vendas.Servicos
{
    public class LeituraCSV
    {
        /// <summary>
        /// Metodo que faz abertura do arquivo csv e faz leitura das linhas e insere na lista
        /// </summary>
        /// <param name="lista">List<string></param>
        /// <returns>List<string></returns>
        public static List<string> LeCSV(List<string> lista)
        {
            StreamReader reader = new StreamReader(File.OpenRead(@"C:\Users\rafae\Downloads\dataset.csv"));

            //Retirando a linha com nome dos campos
            reader.ReadLine();

            string linha;

            while (!reader.EndOfStream)
            {
                lista.Add(linha = reader.ReadLine());
            }
            reader.Close();

            return lista;
        }

    }
}
