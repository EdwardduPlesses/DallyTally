using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.EntryTypes.UpdateEntryType
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateEntryTypeCommandHandler : IRequestHandler<UpdateEntryTypeCommand>
    {
        private readonly IEntryTypeRepository _entryTypeRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateEntryTypeCommandHandler(IEntryTypeRepository entryTypeRepository)
        {
            _entryTypeRepository = entryTypeRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateEntryTypeCommand request, CancellationToken cancellationToken)
        {
            var existingEntryType = await _entryTypeRepository.FindByIdAsync(request.Id, cancellationToken);
            existingEntryType.Type = request.Type;
            existingEntryType.Description = request.Description;
            return Unit.Value;
        }
    }
}