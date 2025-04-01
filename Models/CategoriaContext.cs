using Microsoft.EntityFrameworkCore;

namespace CategoriaApi.Models;

public class CategoriaContext : DbContext
{
    public CategoriaContext(DbContextOptions<CategoriaContext> options)
        : base(options)
    {
    }

    public DbSet<CategoriaItem> CategoriaItems { get; set; } = null!;
}