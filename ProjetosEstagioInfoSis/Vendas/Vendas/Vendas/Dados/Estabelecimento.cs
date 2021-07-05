namespace Vendas.Dados
{
    public class Estabelecimento
    {
        public int idEstabelecimento { get; set; }
        public string nomeEstabelecimento { get; set; }
        public int idEndereco { get; set; }

        public Estabelecimento(int idEstabelecimento, string nomeEstabelecimento, int idEndereco)
        {
            this.idEstabelecimento = idEstabelecimento;
            this.nomeEstabelecimento = nomeEstabelecimento;
            this.idEndereco = idEndereco;
        }
    }
}
