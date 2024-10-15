using Microsoft.EntityFrameworkCore;
using Yobzh.Data.Entities;

namespace Yobzh.Data;

public class YobzhContext : DbContext
{
    public virtual DbSet<Product> Products { get; set; }

    public YobzhContext(DbContextOptions<YobzhContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
