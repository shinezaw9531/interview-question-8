using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Question> Questions { get; set; }
    DbSet<QuestionTranslation> QuestionTranslations { get; set; }
    DbSet<Option> Options { get; set; }
    DbSet<OptionTranslation> OptionTranslations { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}