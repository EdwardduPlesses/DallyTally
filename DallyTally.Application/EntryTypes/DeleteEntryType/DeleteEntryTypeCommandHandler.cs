using System;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.EntryTypes.DeleteEntryType
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteEntryTypeCommandHandler : IRequestHandler<DeleteEntryTypeCommand>
    {
        private readonly IEntryTypeRepository _entryTypeRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteEntryTypeCommandHandler(IEntryTypeRepository entryTypeRepository)
        {
            _entryTypeRepository = entryTypeRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteEntryTypeCommand request, CancellationToken cancellationToken)
        {
            var existingEntryType = await _entryTypeRepository.FindByIdAsync(request.Id, cancellationToken);
            _entryTypeRepository.Remove(existingEntryType);
            return Unit.Value;
        }
    }
}