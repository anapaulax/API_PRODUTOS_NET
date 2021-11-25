using Dapper;
using Microsoft.Extensions.Configuration;
using ProdutosAPI.Models;
using ProdutosAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProdutosAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _configuration;

        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Produto> ConsultaProdutos()
        {
            using var connection = new SqlConnection(_configuration);
            var listaProdutos = connection.Query<Produto>("SELECT * FROM PRODUTO");
            return listaProdutos;
        }

        public Produto CadastraProduto(Produto produto)
        {
            using var connection = new SqlConnection(_configuration);
            var produtoData = connection
                .Execute("INSERT INTO PRODUTO VALUES (@NOME, @DESCRICAO, @VALOR, @ESTOQUE, @DATA_CADASTRO)",
                new { NOME = produto.Nome, 
                    DESCRICAO = produto.Descricao, 
                    VALOR = produto.Valor, 
                    ESTOQUE = produto.Estoque, 
                    DATA_CADASTRO = produto.DataCadastro});

            return produto;
        }

        public IEnumerable<Produto> ConsultaProdutoPorId(int id)
        {
            using var connection = new SqlConnection(_configuration);
            var produto = connection.Query<Produto>($"SELECT * FROM PRODUTO WHERE ID = {id}");
            return produto;
        }
    }
}
