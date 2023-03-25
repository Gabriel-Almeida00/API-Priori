using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;

namespace API_Priori.Repository
{
    public interface ICarteiraInvestimentoRepository : IRepository<CarteiraInvestimento>
    {
        Task<PagedList<CarteiraInvestimento>> GetCarteiraInvestimentos(CarteiraInvestimentoParameters carteiraParameters);
    }
}
