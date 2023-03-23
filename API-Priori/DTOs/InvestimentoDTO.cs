using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API_Priori.Models;

namespace API_Priori.DTOs
{
    public class InvestimentoDTO
    {
        public int InvestimentoId { get; set; }

        public decimal RiscoInvestimento { get; set; }

        public string? Nome { get; set; }

        public string? TipoInvestimento { get; set; }

        public decimal RentabilidadeFixa { get; set; }

        public decimal RentabilidadeVariavel { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public DateTime Vencimento { get; set; }

        public decimal ValorMinimo { get; set; }

        public decimal TempoMinimo { get; set; }
        public ICollection<Atualizacao> ?Atualizacoes { get; set; }

    }
}
