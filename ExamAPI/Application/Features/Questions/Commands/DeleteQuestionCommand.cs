using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Questions.Commands;

public record DeleteQuestionCommand(Guid Id) : IRequest<bool>;

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions.FindAsync(new object[] { request.Id }, cancellationToken);
        if (question == null) return false;

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}