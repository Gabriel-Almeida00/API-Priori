using Microsoft.Extensions.Options;

namespace API_Priori.Models;

public class CarteiraInvestimento
{
    public int CarteiraInvestimentoId { get; set; }

    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    public int InvestimentoId { get; set; }
    public Investimento? Investimento { get; set; }

    public double RentabilidadeFixa { get; set; }
    public double RentabilidadeVariavel { get; set; }
    public DateTime DataEfetuacao { get; set; }
    public Double ValorAplicado { get; set; }
    public DateTime DataEncerramento { get; set; }
    public string? Status { get; set; }
    public double Saldo { get; set; }
}
