namespace API_Priori.Models;

public class Investimento
{
    public int InvestimentoId { get; set; }
    public int RiscoInvestimentoId { get; set; }
    public string? Nome { get; set; }
    public string? TipoInvestimento { get; set; }
    public double RentabilidadeFixa { get; set; }
    public double RentabilidadeVariavel { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime Vencimento { get; set; }
    public double ValorMinimo { get; set; }
    public int TempoMinimo { get; set; }
}
