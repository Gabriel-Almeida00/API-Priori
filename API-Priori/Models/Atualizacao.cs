using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Priori.Models;

public class Atualizacao
{
    [Column("id_atualizacao")]
    public int AtualizacaoId { get; set; }

    [Column("id_consultor")]
    public int ConsultorId { get; set; }

    [JsonIgnore]
    public Consultor? Consultor { get; set; }

    [Column("id_investimento")]
    public int InvestimentoId { get; set; }

    [JsonIgnore]
    public Investimento? Investimento { get; set; }

    [Column("data_atualizacao")]
    public DateTime DataAtualizacao { get; set; }

    [Column("rentFixaAntiga",TypeName = "decimal(8,4")]
    public decimal RentabilidadeFixaAntiga { get; set; }

    [Column("rentFixaAtual",TypeName = "decimal(8,4")]
    public decimal RentabilidadeFixaAtual { get; set; }

    [Column("rentVarAntiga",TypeName = "decimal(8,4")]
    public decimal RentabilidadeVariavelAntiga { get; set; }

    [Column("rentVarAtual",TypeName = "decimal(8,4")]
    public decimal RentabilidadeVariavelAtual { get; set; }

}
