using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Priori.Models;

public class CarteiraInvestimento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_efetuacao")]
    public int CarteiraInvestimentoId { get; set; }

    [Column("id_cliente_carteira")]
    public int ClienteId { get; set; }

    [JsonIgnore]
    public Cliente? Cliente { get; set; }

    [Column("id_investimento")]
    public int InvestimentoId { get; set; }

    [JsonIgnore]
    public Investimento? Investimento { get; set; }

    [Column("rentabilidade_fixa",TypeName = "decimal(8,4")]
    public decimal RentabilidadeFixa { get; set; }

    [Column("rentabilidade_variavel",TypeName = "decimal(8,2")]
    public decimal RentabilidadeVariavel { get; set; }

    [Column("data_efetuacao")]
    public DateTime DataEfetuacao { get; set; }

    [Column("valor_aplicado",TypeName = "decimal(8,4")]
    public decimal ValorAplicado { get; set; }

    [Column("data_encerramento")]
    public DateTime ?DataEncerramento { get; set; }

    [StringLength(10)]
    [Column("status")]
    public string? Status { get; set; }

    [Column("saldo",TypeName = "decimal(8,2")]
    public decimal Saldo { get; set; }

   public ICollection<Investimento> ?Investimentos { get; set; }
}
