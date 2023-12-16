using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class TenderContext
    : DbContext
{
    public DbSet<Tender> Proposals { get; set; }

    public TenderContext(DbContextOptions options)
        : base(options)
    {
    }
}
