using API_Priori.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Priori.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Atualizacao> tblAtualizacao { get; set; }
    public DbSet<CarteiraInvestimento> tblCarteiraInvestimentos { get; set; }

    public DbSet<Cliente> tblClientes { get; set; }

    public DbSet<Consultor> tblConsultores { get; set; }

    public DbSet<Investimento> tblInvestimentos { get; set; }

}
