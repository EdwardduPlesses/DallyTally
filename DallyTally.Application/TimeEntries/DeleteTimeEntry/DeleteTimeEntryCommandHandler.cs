using System;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.TimeEntries.DeleteTimeEntry
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteTimeEntryCommandHandler : IRequestHandler<DeleteTimeEntryCommand>
    {
        private readonly ITimeEntryRepository _timeEntryRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteTimeEntryCommandHandler(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteTimeEntryCommand request, CancellationToken cancellationToken)
        {
            var existingTimeEntry = await _timeEntryRepository.FindByIdAsync(request.Id, cancellationToken);
            _timeEntryRepository.Remove(existingTimeEntry);
            return Unit.Value;
        }
    }
}