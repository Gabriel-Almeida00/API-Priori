using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class ConsultorRepository : Repository<Consultor>, IConsultorRepository
    {
        public ConsultorRepository(AppDbContext contentx) : base(contentx)
        {
        }

        public async Task<PagedList<Consultor>> GetConsultors(ConsultorParameters consultorParameters)
        {
            return await PagedList<Consultor>.ToPagedList(GetAll().OrderBy(x => x.Nome),
                consultorParameters.PageNumber,
                consultorParameters.PageSize);
        }
    }
}
