using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class ConsultorRepository : Repository<Consultor>, IConsultorRepository
    {
        public ConsultorRepository(AppDbContext contentx) : base(contentx)
        {
        }
    }
}
