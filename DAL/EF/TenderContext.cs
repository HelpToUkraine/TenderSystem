using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class TenderContext
    : DbContext
{
    public DbSet<Tender> Tenders { get; set; }
    public DbSet<Proposal> Proposals { get; set; }

    public TenderContext(DbContextOptions options)
        : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Proposal>()
    //         .HasKey(p => p.IdProposal);
    //
    //     // Other configurations...
    //
    //     base.OnModelCreating(modelBuilder);
    // }
}
