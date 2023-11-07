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

namespace DallyTally.Application.EntryTypes.CreateEntryType
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateEntryTypeCommandHandler : IRequestHandler<CreateEntryTypeCommand, Guid>
    {
        private readonly IEntryTypeRepository _entryTypeRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateEntryTypeCommandHandler(IEntryTypeRepository entryTypeRepository)
        {
            _entryTypeRepository = entryTypeRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateEntryTypeCommand request, CancellationToken cancellationToken)
        {
            var newEntryType = new EntryType
            {
                Type = request.Type,
                Description = request.Description,
            };

            _entryTypeRepository.Add(newEntryType);
            await _entryTypeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newEntryType.Id;
        }
    }
}