namespace API_Priori.Models;

public class Atualizacao
{
    public int AtualizacaoId { get; set; }
    public int ConsultorId { get; set; }
    public int InvestimentoId { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public double RentabilidadeFixaAntiga { get; set; }
    public double RentabilidadeFixaAtual { get; set; }
    public double RentabilidadeVariavelAntiga { get; set; }
    public double RentabilidadeVariavelAtual { get; set; }

}
