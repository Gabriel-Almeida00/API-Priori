using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace API_Priori.Models;

public class Consultor
{
    public Consultor()
    {
        Clientes = new Collection<Cliente>();
        Atualizacaoes = new Collection<Atualizacao>();
    }

    public int ConsultorId { get; set; }

    [StringLength(40)]
    public string? Nome { get; set; }

    [StringLength(11)]
    public string? CPF { get; set; }

    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [StringLength(11)]
    public string? Telefone { get; set; }
    public DateTime DataContratacao { get; set; }
    public DateTime DataDemissao { get; set; }

    [StringLength(11)]
    public string? Status { get; set; }

    [StringLength(20)]
    public string? Usuario { get; set; }

    [DataType(DataType.Password)]
    public string? Senha { get; set; }

    public ICollection<Cliente> Clientes { get; set; }
    public ICollection<Atualizacao> Atualizacaoes { get; set; }
}
