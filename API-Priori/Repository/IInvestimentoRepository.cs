using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;

namespace API_Priori.Repository
{
    public interface IInvestimentoRepository : IRepository<Investimento>
    {
        PagedList<Investimento> GetInvestimentos(InvestimentoParameters investimentoParameters);
        IEnumerable<Investimento> GetInvestimentosByAtualizacao();
    }
}
