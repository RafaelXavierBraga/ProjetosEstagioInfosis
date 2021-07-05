using System;

namespace Vendas.Dados
{
    public class Venda
    {

        public long idProduto { get; set; }
        public int idEstabelecimento { get; set; }
        public long codigoBarra { get; set; }
        public DateTime dataHora { get; set; }
        public string tipoPagamento { get; set; }
        public double valor { get; set; }

        public Venda(long idProduto, int idEstabelecimento, long codigoBarra, DateTime dataHora, string tipoPagamento, double valor)
        {
            this.idProduto = idProduto;
            this.idEstabelecimento = idEstabelecimento;
            this.codigoBarra = codigoBarra;
            this.dataHora = dataHora;
            this.tipoPagamento = tipoPagamento;
            this.valor = valor;
        }
    }
}
