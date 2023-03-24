using API_Priori.Models;
using API_Priori.Pagination;
using API_Priori.Pagination.PaginationImpl;

namespace API_Priori.Repository
{
    public interface IAtualizacaoRepository : IRepository<Atualizacao>
    {
        PagedList<Atualizacao> GetAtualizacaos(AtualizacaoParameters atualizacaoParameters);
    }
}
