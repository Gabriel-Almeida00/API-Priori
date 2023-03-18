using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Priori.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [StringLength(40)]
        public string? Nome { get; set; }
        public int TipoInvestidor { get; set; }

        public int ConsultorId { get; set; }
        public Consultor? Consultor { get; set; }


        [StringLength(11)]
        public string? CPF { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Column(TypeName = "decimal(8,4")]
        public decimal pontuacao { get; set; }

        [StringLength(50)]
        public string? Endereco { get; set; }

        [StringLength(11)]
        public string? Telefone { get; set; }   
        public DateTime DataAdesao { get; set; }

        [StringLength(8)]
        public string? Status { get; set; }
    }
}
