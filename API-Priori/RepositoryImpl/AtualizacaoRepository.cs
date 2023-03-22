using API_Priori.Context;
using API_Priori.Models;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class AtualizacaoRepository : Repository<Atualizacao>, IAtualizacaoRepository
    {
        public AtualizacaoRepository(AppDbContext contentx) : base(contentx)
        {
        }
    }
}
