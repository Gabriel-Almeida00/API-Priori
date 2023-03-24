using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class CarteiraInvestimentoRepository : Repository<CarteiraInvestimento>, ICarteiraInvestimentoRepository
    {
        public CarteiraInvestimentoRepository(AppDbContext contentx) : base(contentx)
        {
        }

        public PagedList<CarteiraInvestimento> GetCarteiraInvestimentos(CarteiraInvestimentoParameters carteiraParameters)
        {
            return PagedList<CarteiraInvestimento>.ToPagedList(GetAll().OrderBy(x => x.DataEfetuacao),
                carteiraParameters.PageNumber,
                carteiraParameters.PageSize);
        }
    }
}
