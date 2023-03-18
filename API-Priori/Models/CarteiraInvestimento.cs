using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Priori.Models;

public class CarteiraInvestimento
{
    public int CarteiraInvestimentoId { get; set; }

    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    public int InvestimentoId { get; set; }
    public Investimento? Investimento { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal RentabilidadeFixa { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal RentabilidadeVariavel { get; set; }
    public DateTime DataEfetuacao { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal ValorAplicado { get; set; }
    public DateTime DataEncerramento { get; set; }

    [StringLength(80)]
    public string? Status { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal Saldo { get; set; }
}
