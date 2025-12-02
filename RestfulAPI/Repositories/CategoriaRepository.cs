using Microsoft.EntityFrameworkCore;
using RESTFulAPI.Data;
using RESTFulAPI.Entities;

namespace RESTFulAPI.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly ApplicationDbContext dbContext;
        
        public CategoriaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await dbContext.Categorias
                  .Where(x => x.Imagem.Length > 0)
                  .OrderBy(O=> O.Ordem)
                  .ThenBy(p => p.Nome)
                  .ToListAsync();
        }
    }
}
