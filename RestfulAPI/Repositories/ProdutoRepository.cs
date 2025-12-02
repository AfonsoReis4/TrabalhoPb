using RESTFulAPI.Data;
using RESTFulAPI.Entities;
using Microsoft.EntityFrameworkCore;
using RESTFulAPI.Repositories;

namespace RESTFulAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly ApplicationDbContext dbContext;
        public ProdutoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Produto> ObterDetalheProdutoAsync(int id)
        {
            var detalhe = await dbContext.Produtos
                .Include(p => p.categoria)
                .Include(p => p.modoentrega)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (detalhe is null)
            {
                throw new InvalidOperationException();
            }

            return detalhe;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(int categoriaId)
        {
            return await dbContext.Produtos.
                Include(p => p.categoria).
                Include(p => p.modoentrega).
                Where(p => p.CategoriaId == categoriaId).
                OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosMaisVendidosAsync()
        {
            return await dbContext.Produtos.
                Include(p => p.categoria).
                Include(p => p.modoentrega).
                Where(p => p.MaisVendido == true).
                OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPromocaoAsync()
        {
            return await dbContext.Produtos.
                Include(p => p.categoria).
                Include(p => p.modoentrega).
                Where(p => p.Promocao == true).
                OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutosAsync()
        {
            return await dbContext.Produtos.
                Include(p => p.categoria).
                Include(p => p.modoentrega).
                OrderBy(p => p.Nome).ToListAsync();
        }
    }
}


