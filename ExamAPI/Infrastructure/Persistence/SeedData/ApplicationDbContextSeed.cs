using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.SeedData;

public static class ApplicationDbContextSeed
{
    // GUID Definitions
    public static readonly Guid Q1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid Q1Opt1Id = Guid.Parse("11111111-1111-1111-1111-111111111101");
    public static readonly Guid Q1Opt2Id = Guid.Parse("11111111-1111-1111-1111-111111111102");
    public static readonly Guid Q1Opt3Id = Guid.Parse("11111111-1111-1111-1111-111111111103");
    public static readonly Guid Q1Opt4Id = Guid.Parse("11111111-1111-1111-1111-111111111104");

    public static readonly Guid Q2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid Q2Opt1Id = Guid.Parse("22222222-2222-2222-2222-222222222201");
    public static readonly Guid Q2Opt2Id = Guid.Parse("22222222-2222-2222-2222-222222222202");
    public static readonly Guid Q2Opt3Id = Guid.Parse("22222222-2222-2222-2222-222222222203");
    public static readonly Guid Q2Opt4Id = Guid.Parse("22222222-2222-2222-2222-222222222204");

    public static readonly Guid Q3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public static readonly Guid Q3Opt1Id = Guid.Parse("33333333-3333-3333-3333-333333333301");
    public static readonly Guid Q3Opt2Id = Guid.Parse("33333333-3333-3333-3333-333333333302");
    public static readonly Guid Q3Opt3Id = Guid.Parse("33333333-3333-3333-3333-333333333303");
    public static readonly Guid Q3Opt4Id = Guid.Parse("33333333-3333-3333-3333-333333333304");

    private static readonly DateTime SeedTimestamp = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Only run if the database has NO questions yet
        if (await context.Questions.AnyAsync())
        {
            return; // Data already exists, skip seeding
        }

        // 1. Seed Questions
        var questions = new List<Question>
        {
            new Question { Id = Q1Id, DisplayOrder = 1, CreatedAt = SeedTimestamp },
            new Question { Id = Q2Id, DisplayOrder = 2, CreatedAt = SeedTimestamp },
            new Question { Id = Q3Id, DisplayOrder = 3, CreatedAt = SeedTimestamp }
        };
        await context.Questions.AddRangeAsync(questions);

        // 2. Seed Question Translations
        var questionTranslations = new List<QuestionTranslation>
        {
            new QuestionTranslation { Id = Guid.NewGuid(), QuestionId = Q1Id, LanguageCode = "th", Text = "ข้อใดคือเมืองหลวงของประเทศไทย?" },
            new QuestionTranslation { Id = Guid.NewGuid(), QuestionId = Q1Id, LanguageCode = "en", Text = "What is the capital of Thailand?" },
            new QuestionTranslation { Id = Guid.NewGuid(), QuestionId = Q2Id, LanguageCode = "th", Text = "ภาษาใดใช้สำหรับการพัฒนา backend ด้วย .NET 8?" },
            new QuestionTranslation { Id = Guid.NewGuid(), QuestionId = Q2Id, LanguageCode = "en", Text = "Which programming language is primarily used for backend development in .NET 8?" },
            new QuestionTranslation { Id = Guid.NewGuid(), QuestionId = Q3Id, LanguageCode = "th", Text = "เครื่องมือใดใช้สำหรับสร้าง UI frontend ในโปรเจกต์นี้?" },
            new QuestionTranslation { Id = Guid.NewGuid(), QuestionId = Q3Id, LanguageCode = "en", Text = "Which framework is used for building the UI frontend in this project?" }
        };
        await context.QuestionTranslations.AddRangeAsync(questionTranslations);

        // 3. Seed Options
        var options = new List<Option>
        {
            new Option { Id = Q1Opt1Id, QuestionId = Q1Id, OptionNumber = 1 },
            new Option { Id = Q1Opt2Id, QuestionId = Q1Id, OptionNumber = 2 },
            new Option { Id = Q1Opt3Id, QuestionId = Q1Id, OptionNumber = 3 },
            new Option { Id = Q1Opt4Id, QuestionId = Q1Id, OptionNumber = 4 },
            new Option { Id = Q2Opt1Id, QuestionId = Q2Id, OptionNumber = 1 },
            new Option { Id = Q2Opt2Id, QuestionId = Q2Id, OptionNumber = 2 },
            new Option { Id = Q2Opt3Id, QuestionId = Q2Id, OptionNumber = 3 },
            new Option { Id = Q2Opt4Id, QuestionId = Q2Id, OptionNumber = 4 },
            new Option { Id = Q3Opt1Id, QuestionId = Q3Id, OptionNumber = 1 },
            new Option { Id = Q3Opt2Id, QuestionId = Q3Id, OptionNumber = 2 },
            new Option { Id = Q3Opt3Id, QuestionId = Q3Id, OptionNumber = 3 },
            new Option { Id = Q3Opt4Id, QuestionId = Q3Id, OptionNumber = 4 }
        };
        await context.Options.AddRangeAsync(options);

        // 4. Seed Option Translations
        var optionTranslations = new List<OptionTranslation>
        {
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q1Opt1Id, LanguageCode = "th", Text = "กรุงเทพมหานคร" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q1Opt1Id, LanguageCode = "en", Text = "Bangkok" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q1Opt2Id, LanguageCode = "th", Text = "เชียงใหม่" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q1Opt2Id, LanguageCode = "en", Text = "Chiang Mai" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q1Opt3Id, LanguageCode = "th", Text = "ภูเก็ต" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q1Opt3Id, LanguageCode = "en", Text = "Phuket" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q1Opt4Id, LanguageCode = "th", Text = "ชลบุรี" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q1Opt4Id, LanguageCode = "en", Text = "Chonburi" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q2Opt1Id, LanguageCode = "th", Text = "C#" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q2Opt1Id, LanguageCode = "en", Text = "C#" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q2Opt2Id, LanguageCode = "th", Text = "Python" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q2Opt2Id, LanguageCode = "en", Text = "Python" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q2Opt3Id, LanguageCode = "th", Text = "Java" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q2Opt3Id, LanguageCode = "en", Text = "Java" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q2Opt4Id, LanguageCode = "th", Text = "PHP" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q2Opt4Id, LanguageCode = "en", Text = "PHP" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q3Opt1Id, LanguageCode = "th", Text = "Angular" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q3Opt1Id, LanguageCode = "en", Text = "Angular" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q3Opt2Id, LanguageCode = "th", Text = "React" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q3Opt2Id, LanguageCode = "en", Text = "React" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q3Opt3Id, LanguageCode = "th", Text = "Vue.js" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q3Opt3Id, LanguageCode = "en", Text = "Vue.js" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q3Opt4Id, LanguageCode = "th", Text = "Svelte" },
            new OptionTranslation { Id = Guid.NewGuid(), OptionId = Q3Opt4Id, LanguageCode = "en", Text = "Svelte" }
        };
        await context.OptionTranslations.AddRangeAsync(optionTranslations);

        // Save everything to DB
        await context.SaveChangesAsync();
    }
}