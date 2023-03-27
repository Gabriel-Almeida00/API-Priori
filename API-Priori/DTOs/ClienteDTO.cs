using API_Priori.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace API_Priori.DTOs
{
    public class ClienteDTO : IdentityUser
    {
        public int ClienteId { get; set; }

        public string? Nome { get; set; }

        public int TipoInvestidor { get; set; }

        public string? CPF { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public string? Endereco { get; set; }

        public string? Telefone { get; set; }
        public DateTime DataAdesao { get; set; }

    }
}
