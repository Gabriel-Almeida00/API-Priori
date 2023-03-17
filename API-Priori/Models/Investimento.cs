namespace API_Priori.Models;

public class Investimento
{
    public int InvestimentoId { get; set; }
    public int RiscoInvestimentoId { get; set; }
    public string? Nome { get; set; }
    public string? TipoInvestimento { get; set; }
    public int RentabilidadeFixa { get; set; }
    public int RentabilidadeVariavel { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime Vencimento { get; set; }
    public int ValorMinimo { get; set; }
    public int TempoMinimo { get; set; }
}
