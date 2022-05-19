using Teste_API_Banco_2.Data;
using Teste_API_Banco_2.Models;

namespace Teste_API_Banco_2.Repositories
{
    public class ClienteRepository : GenericRepository<TabCliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext repositoryCext) 
            : base(repositoryCext)
        {
    
        }
    }
}
