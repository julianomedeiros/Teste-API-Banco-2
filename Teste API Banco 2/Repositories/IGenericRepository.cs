using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste_API_Banco_2.Repositories
{
    public interface IGenericRepository<T> where T : class //- aqui T é uma classe;
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T obj);
        Task Update(int id, T obj);
        Task Delete(int id);
    }
}
