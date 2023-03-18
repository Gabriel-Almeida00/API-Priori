using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Priori.Models;

public class Investimento
{
    public Investimento()
    {
        Atualizacoes = new Collection<Atualizacao>();
    }

    public int InvestimentoId { get; set; }

    [Column(TypeName = "decimal(3,0")]
    public int RiscoInvestimento { get; set; }

    [StringLength(40)]
    public string? Nome { get; set; }

    [StringLength(10)]
    public string? TipoInvestimento { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal RentabilidadeFixa { get; set; }

    [Column(TypeName = "decimal(8,2")]
    public decimal RentabilidadeVariavel { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime Vencimento { get; set; }

    [Column(TypeName = "decimal(8,2")]
    public decimal ValorMinimo { get; set; }

    [Column(TypeName = "decimal(3,0")]
    public decimal TempoMinimo { get; set; }

    public ICollection<Atualizacao> Atualizacoes { get; set; }
}
