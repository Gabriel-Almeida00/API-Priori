using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class InvestimentoRepository : Repository<Investimento>, IInvestimentoRepository
    {
        public InvestimentoRepository(AppDbContext contentx) : base(contentx)
        {
        }
    }
}
