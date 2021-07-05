namespace Vendas.Dados
{
    public class Produto
    {
        public long codigoBarra { get; set; }
        public long idProduto { get; set; }
        public int idNCM { get; set; }
        public string tipoUnidade { get; set; }
        public string descricaoProduto { get; set; }
        public double valor { get; set; }
        public int idEstabelecimento { get; set; }

        public Produto(long codigoBarra, long idProduto, int idNCM, string tipoUnidade, string descricaoProduto, double valor, int idEstabelecimento)
        {
            this.codigoBarra = codigoBarra;
            this.idProduto = idProduto;
            this.idNCM = idNCM;
            this.tipoUnidade = tipoUnidade;
            this.descricaoProduto = descricaoProduto;
            this.valor = valor;
            this.idEstabelecimento = idEstabelecimento;
        }

    }
}
