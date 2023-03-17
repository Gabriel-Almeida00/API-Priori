using API_Priori.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Priori.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Atualizacao> Atualizacaos { get; set; }
    public DbSet<CarteiraInvestimento> CarteiraInvestimentos { get; set; }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Consultor> Consultors { get; set; }

    public DbSet<Investimento> Investimentos { get; set; }

}
