using API_Priori.Context;
using API_Priori.Repository;

namespace API_Priori.RepositoryImpl
{
    public class UnitOfWork : IUnitOfWork
    {
        private AtualizacaoRepository atualizacaoRepository;
        private CarteiraInvestimentoRepository carteiraInvestimentoRepository;
        private ClienteRepository clienteRepository;
        private ConsultorRepository consultorRepository;
        private InvestimentoRepository investimentoRepository;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAtualizacaoRepository AtualizacaoRepository
        {
            get
            {
                return atualizacaoRepository = atualizacaoRepository ?? new AtualizacaoRepository(_context);
            }
        }

        public ICarteiraInvestimentoRepository CarteiraInvestimentoRepository
        {
            get
            {
                return carteiraInvestimentoRepository = carteiraInvestimentoRepository ?? new CarteiraInvestimentoRepository(_context);
            }
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return clienteRepository = clienteRepository ?? new ClienteRepository(_context);
            }
        }

        public IConsultorRepository ConsultorRepository
        {
            get
            {
                return consultorRepository = consultorRepository ?? new ConsultorRepository(_context);
            }
        }

        public IInvestimentoRepository InvestimentoRepository
        {
            get
            {
                return investimentoRepository = investimentoRepository ?? new InvestimentoRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
