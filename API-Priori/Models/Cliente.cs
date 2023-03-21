using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Priori.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_cliente")]
        public int ClienteId { get; set; }

        [StringLength(40)]
        [Column("nome_c")]
        public string? Nome { get; set; }

        [Column("id_tipoinvestidor")]
        public int TipoInvestidor { get; set; }

        [Column("id_consultor")]
        public int ConsultorId { get; set; }

        [JsonIgnore]
        public Consultor? Consultor { get; set; }


        [StringLength(11)]
        [Column("cpf_c")]
        public string? CPF { get; set; }

        [DataType(DataType.EmailAddress)]
        [Column("email")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Column("Senha")]
        public string? Senha { get; set; }

        [Column(TypeName = "decimal(8,4")]
        public decimal ?pontuacao { get; set; }

        [StringLength(50)]
        [Column("endereco")]
        public string? Endereco { get; set; }

        [StringLength(11)]
        [Column("telefone")]
        public string? Telefone { get; set; }

        [Column("data_adesao")]
        public DateTime DataAdesao { get; set; }

        [StringLength(8)]
        [Column("status_c")]
        public string? Status { get; set; }
    }
}
