﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Priori.Models;

public class Investimento
{
    public Investimento()
    {
        Atualizacoes = new Collection<Atualizacao>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_investimento")]
    public int InvestimentoId { get; set; }

    [Column("id_riscoInvestimento",TypeName = "decimal(18,0")]
    public decimal RiscoInvestimento { get; set; }

    [StringLength(40)]
    [Column("nome")]
    public string? Nome { get; set; }

    [StringLength(5)]
    [Column("tipo_investimento")]
    public string? TipoInvestimento { get; set; }

    [Column("rentabilidade_fixa",TypeName = "decimal(8,4")]
    public decimal RentabilidadeFixa { get; set; }

    [Column("rentabilidade_variavel",TypeName = "decimal(8,2")]
    public decimal RentabilidadeVariavel { get; set; }

    [Column("data_atualizacao")]
    public DateTime DataAtualizacao { get; set; }

    [Column("vencimento")]
    [DataType((DataType.Date))]
    public DateTime Vencimento { get; set; }

    [Column("valor_minimo",TypeName = "decimal(8,2")]
    public decimal ValorMinimo { get; set; }

    [Column("tempo_minimo",TypeName = "decimal(3,0")]
    public decimal TempoMinimo { get; set; }

    public ICollection<Atualizacao> Atualizacoes { get; set; }
}
