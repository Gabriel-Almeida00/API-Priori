namespace API_Priori.DTOs
{
    public class CarteiraInvestimentoDTO
    {
        public int CarteiraInvestimentoId { get; set; }
        public int ClienteId { get; set; }
        public int InvestimentoId { get; set; }
        public decimal RentabilidadeFixa { get; set; }
        public decimal RentabilidadeVariavel { get; set; }
        public DateTime DataEfetuacao { get; set; }
        public decimal ValorAplicado { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public string? Status { get; set; }
        public decimal Saldo { get; set; }

    }
}
