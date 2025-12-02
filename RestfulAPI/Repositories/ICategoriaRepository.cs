using RESTFulAPI.Entities;

namespace RESTFulAPI.Repositories
{
    public interface ICategoriaRepository
    {
       Task<IEnumerable<Categoria>> GetCategorias();
    }
}
