using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;

namespace API_Priori.Repository
{
    public interface IConsultorRepository : IRepository<Consultor>
    {
        Task<PagedList<Consultor>> GetConsultors(ConsultorParameters consultorParameters);
    }
}
