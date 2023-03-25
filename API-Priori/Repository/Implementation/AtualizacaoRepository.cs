using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class AtualizacaoRepository : Repository<Atualizacao>, IAtualizacaoRepository
    {
        public AtualizacaoRepository(AppDbContext contentx) : base(contentx)
        {
        }

        public async Task<PagedList<Atualizacao>> GetAtualizacaos(AtualizacaoParameters atualizacaoParameters)
        {
            return await PagedList<Atualizacao>.ToPagedList(GetAll().OrderBy(x => x.DataAtualizacao),
                atualizacaoParameters.PageNumber,
                atualizacaoParameters.PageSize);
        }
    }
}
