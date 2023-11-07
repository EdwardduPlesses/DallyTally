using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Entities;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.TimeEntries.CreateTimeEntry
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateTimeEntryCommandHandler : IRequestHandler<CreateTimeEntryCommand, Guid>
    {
        private readonly ITimeEntryRepository _timeEntryRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateTimeEntryCommandHandler(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateTimeEntryCommand request, CancellationToken cancellationToken)
        {
            var newTimeEntry = new TimeEntry
            {
                EntryDate = request.EntryDate,
                Date = request.Date,
                UserId = request.UserId,
                EntryTypeId = request.EntryTypeId,
            };

            _timeEntryRepository.Add(newTimeEntry);
            await _timeEntryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newTimeEntry.Id;
        }
    }
}