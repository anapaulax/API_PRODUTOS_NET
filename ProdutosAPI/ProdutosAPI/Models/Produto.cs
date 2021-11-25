using System;

namespace ProdutosAPI.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
