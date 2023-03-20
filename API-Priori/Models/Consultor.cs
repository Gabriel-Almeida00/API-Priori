using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Priori.Models;

public class Consultor
{
    public Consultor()
    {
        Clientes = new Collection<Cliente>();
        Atualizacaoes = new Collection<Atualizacao>();
    }

    [Column("id_consultor")]
    public int ConsultorId { get; set; }

    [StringLength(40)]
    [Column("nome")]
    public string? Nome { get; set; }

    [StringLength(11)]
    [Column("cpf_f")]
    public string? CPF { get; set; }

    [DataType(DataType.EmailAddress)]
    [Column("email")]
    public string? Email { get; set; }

    [StringLength(11)]
    [Column("telefone")]
    public string? Telefone { get; set; }

    [Column("data_contratacao")]
    public DateTime DataContratacao { get; set; }

    [Column("data_demissao")]
    public DateTime ?DataDemissao { get; set; }

    [StringLength(11)]
    [Column("status")]
    public string? Status { get; set; }

    [StringLength(20)]
    [Column("usuario")]
    public string? Usuario { get; set; }

    [DataType(DataType.Password)]
    [Column("senha")]
    public string? Senha { get; set; }

    public ICollection<Cliente> Clientes { get; set; }
    public ICollection<Atualizacao> Atualizacaoes { get; set; }
}
