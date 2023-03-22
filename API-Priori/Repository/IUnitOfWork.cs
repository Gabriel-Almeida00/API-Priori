namespace API_Priori.Repository
{
    public interface IUnitOfWork
    {
        IAtualizacaoRepository AtualizacaoRepository { get; }
        ICarteiraInvestimentoRepository CarteiraInvestimentoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IConsultorRepository ConsultorRepository { get; }
        IInvestimentoRepository InvestimentoRepository { get; }
        void Commit();
    }
}
