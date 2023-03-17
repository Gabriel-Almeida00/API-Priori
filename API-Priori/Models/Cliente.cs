namespace API_Priori.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public int TipoInvestidorId { get; set; }
        public int ConsultorId { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int pontuacao { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }   
        public DateTime DataAdesao { get; set; }
        public string Status { get; set; }
    }
}
