using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Priori.Models;

public class Atualizacao
{
    public int AtualizacaoId { get; set; }

    public int ConsultorId { get; set; }
    public Consultor? Consultor { get; set; }

    public int InvestimentoId { get; set; }
    public Investimento? Investimento { get; set; }

    public DateTime DataAtualizacao { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal RentabilidadeFixaAntiga { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal RentabilidadeFixaAtual { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal RentabilidadeVariavelAntiga { get; set; }

    [Column(TypeName = "decimal(8,4")]
    public decimal RentabilidadeVariavelAtual { get; set; }

}
