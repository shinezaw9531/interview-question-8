namespace Domain.Entities;

public class OptionTranslation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OptionId { get; set; }
    public string LanguageCode { get; set; } = null!; // "th", "en"
    public string Text { get; set; } = null!;

    public Option Option { get; set; } = null!;
}