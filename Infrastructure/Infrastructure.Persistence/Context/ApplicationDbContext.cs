using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<WordTypeEntity> WordType { get; set; }
    public DbSet<WordLibraryEntity> WordLibrary { get; set; }
    public DbSet<ConstructedSentenceEntity> ConstructedSentence { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //seeding database with predefined values

    }
  }
}