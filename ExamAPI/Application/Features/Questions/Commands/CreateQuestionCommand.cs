using Application.Common.Interfaces;
using Application.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Questions.Commands;

public record CreateQuestionCommand(
    List<TranslationInputDto> Translations,
    List<OptionInputDto> Options
) : IRequest<Guid>;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateQuestionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var maxOrder = await _context.Questions.MaxAsync(q => (int?)q.DisplayOrder, cancellationToken) ?? 0;

        var question = new Question
        {
            DisplayOrder = maxOrder + 1,
            Translations = request.Translations.Select(t => new QuestionTranslation
            {
                LanguageCode = t.LanguageCode.ToLower(),
                Text = t.Text
            }).ToList(),
            Options = request.Options.Select(o => new Option
            {
                OptionNumber = o.OptionNumber,
                Translations = o.Translations.Select(ot => new OptionTranslation
                {
                    LanguageCode = ot.LanguageCode.ToLower(),
                    Text = ot.Text
                }).ToList()
            }).ToList()
        };

        _context.Questions.Add(question);
        await _context.SaveChangesAsync(cancellationToken);

        return question.Id;
    }
}