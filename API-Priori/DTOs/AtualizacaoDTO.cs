using API_Priori.Models;


namespace API_Priori.DTOs
{
    public class AtualizacaoDTO
    {
        
        public int AtualizacaoId { get; set; }

        public int InvestimentoId { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public decimal RentabilidadeFixaAtual { get; set; }
        public decimal RentabilidadeFixaAntiga { get; set; }
        public decimal RentabilidadeVariavelAntiga { get; set; }
        public decimal RentabilidadeVariavelAtual { get; set; }
    }
}
