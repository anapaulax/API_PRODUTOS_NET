using ProdutosAPI.Models;
using System.Collections.Generic;

namespace ProdutosAPI.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ConsultaProdutos();
        Produto CadastraProduto(Produto produto);
        IEnumerable<Produto> ConsultaProdutoPorId(int id);
    }
}
