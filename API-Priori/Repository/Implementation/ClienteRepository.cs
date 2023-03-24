using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext contentx) : base(contentx)
        {
        }

        public PagedList<Cliente> GetClientes(ClienteParameters clienteParameters)
        {
            return PagedList<Cliente>.ToPagedList(GetAll().OrderBy(x => x.Nome),
                clienteParameters.PageNumber,
                clienteParameters.PageSize);
        }
    }
}
