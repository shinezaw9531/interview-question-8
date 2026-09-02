using Application.Common.Interfaces;
using Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Questions.Queries;

public record GetQuestionsQuery(string LanguageCode = "th") : IRequest<List<QuestionDto>>;

public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, List<QuestionDto>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<QuestionDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        var lang = request.LanguageCode.ToLower();

        var questions = await _context.Questions
            .AsNoTracking()
            .Include(q => q.Translations)
            .Include(q => q.Options)
                .ThenInclude(o => o.Translations)
            .OrderBy(q => q.DisplayOrder)
            .ToListAsync(cancellationToken);

        return questions.Select(q => new QuestionDto(
            q.Id,
            q.DisplayOrder,
            q.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Text
                ?? q.Translations.FirstOrDefault(t => t.LanguageCode == "th")?.Text
                ?? string.Empty,
            q.Options.Select(o => new OptionDto(
                o.Id,
                o.OptionNumber,
                o.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Text
                    ?? o.Translations.FirstOrDefault(t => t.LanguageCode == "th")?.Text
                    ?? string.Empty
            )).OrderBy(o => o.OptionNumber).ToList()
        )).ToList();
    }
}