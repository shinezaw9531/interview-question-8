namespace Domain.Entities;

public class Option
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuestionId { get; set; }
    public int OptionNumber { get; set; }

    public Question Question { get; set; } = null!;
    public ICollection<OptionTranslation> Translations { get; set; } = new List<OptionTranslation>();
}