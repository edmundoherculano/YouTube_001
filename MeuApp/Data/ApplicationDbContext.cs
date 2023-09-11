using MeuApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }

    }
}
