using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_Priori.RepositoryImpl
{
    public class InvestimentoRepository : Repository<Investimento>, IInvestimentoRepository
    {
        public InvestimentoRepository(AppDbContext contentx) : base(contentx)
        {
        }

        public IEnumerable<Investimento> GetInvestimentosByAtualizacao()
        {
            return GetAll().Include(x => x.Atualizacoes);
        }
    }
}
