using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.TimeEntries.UpdateTimeEntry
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateTimeEntryCommandHandler : IRequestHandler<UpdateTimeEntryCommand>
    {
        private readonly ITimeEntryRepository _timeEntryRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateTimeEntryCommandHandler(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateTimeEntryCommand request, CancellationToken cancellationToken)
        {
            var existingTimeEntry = await _timeEntryRepository.FindByIdAsync(request.Id, cancellationToken);
            existingTimeEntry.EntryDate = request.EntryDate;
            existingTimeEntry.Date = request.Date;
            existingTimeEntry.UserId = request.UserId;
            existingTimeEntry.EntryTypeId = request.EntryTypeId;
            return Unit.Value;
        }
    }
}