namespace API_Priori.Models;

public class Consultore
{
    public int ConsultorId { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public DateTime DataContratacao { get; set; }
    public DateTime DataDemissao { get; set; }
    public string? Status { get; set; }
    public string? Usuario { get; set; }
    public string? Senha { get; set; }
}
