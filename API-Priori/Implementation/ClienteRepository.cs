using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext contentx) : base(contentx)
        {
        }
    }
}
