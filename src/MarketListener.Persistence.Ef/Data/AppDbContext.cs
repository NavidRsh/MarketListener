namespace MarketListener.Persistence.Ef.Data;

using MarketListener.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext
{
	public AppDbContext()
	{

	}

    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<Meaning> Meanings { get; set; }
    public DbSet<MeaningExample> MeaningExamples { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            
            optionsBuilder.UseSqlServer("Server=localhost;Database=MarketListener;Integrated Security=True;TrustServerCertificate=True;");
        }     

#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine);
#endif

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //new BondContextInitializer(modelBuilder).Seed();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }


}
