namespace Vendas.Dados
{
    public class Endereco
    {

        public int id { get; set; }
        public string logradouro { get; set; }
        public string numeroLogradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public int codigoMunicipioIBGE { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public int cep { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Endereco(int id, string logradouro, string numeroLogradouro, string complemento, string bairro, int codigoMunicipioIBGE, string municipio, string estado, int cep, double latitude, double longitude)
        {
            this.id = id;
            this.logradouro = logradouro;
            this.numeroLogradouro = numeroLogradouro;
            this.complemento = complemento;
            this.bairro = bairro;
            this.codigoMunicipioIBGE = codigoMunicipioIBGE;
            this.municipio = municipio;
            this.estado = estado;
            this.cep = cep;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
