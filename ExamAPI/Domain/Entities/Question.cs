namespace Domain.Entities;

public class Question
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int DisplayOrder { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<QuestionTranslation> Translations { get; set; } = new List<QuestionTranslation>();
    public ICollection<Option> Options { get; set; } = new List<Option>();
}