namespace Domain.Entities;

public class QuestionTranslation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuestionId { get; set; }
    public string LanguageCode { get; set; } = null!; // "th", "en"
    public string Text { get; set; } = null!;

    public Question Question { get; set; } = null!;
}