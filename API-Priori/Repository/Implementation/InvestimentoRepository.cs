using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;
using API_Priori.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace API_Priori.RepositoryImpl
{
    public class InvestimentoRepository : Repository<Investimento>, IInvestimentoRepository
    {
        public InvestimentoRepository(AppDbContext contentx) : base(contentx)
        {
        }

        public async Task<IEnumerable<Investimento>> GetInvestimentosByAtualizacao()
        {
            return await GetAll().Include(x => x.Atualizacoes).ToListAsync();
        }

        public PagedList<Investimento> GetInvestimentos(InvestimentoParameters investimentoParameters)
        {
            return PagedList<Investimento>.ToPagedList(GetAll().OrderBy(x => x.Nome),
                investimentoParameters.PageNumber,
                investimentoParameters.PageSize);
        }
    }
}
