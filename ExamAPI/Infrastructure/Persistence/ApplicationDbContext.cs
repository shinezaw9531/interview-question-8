using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<QuestionTranslation> QuestionTranslations { get; set; } = null!;
    public DbSet<Option> Options { get; set; } = null!;
    public DbSet<OptionTranslation> OptionTranslations { get; set; } = null!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<QuestionTranslation>()
            .HasIndex(qt => new { qt.QuestionId, qt.LanguageCode })
            .IsUnique();

        modelBuilder.Entity<OptionTranslation>()
            .HasIndex(ot => new { ot.OptionId, ot.LanguageCode })
            .IsUnique();
    }
}