using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;

namespace API_Priori.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<PagedList<Cliente>> GetClientes(ClienteParameters clienteParameters);
    }
}
