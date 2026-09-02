namespace Application.Dtos;

public record OptionDto(Guid Id, int OptionNumber, string Text);
public record QuestionDto(Guid Id, int DisplayOrder, string Text, List<OptionDto> Options);

public record TranslationInputDto(string LanguageCode, string Text);
public record OptionInputDto(int OptionNumber, List<TranslationInputDto> Translations);