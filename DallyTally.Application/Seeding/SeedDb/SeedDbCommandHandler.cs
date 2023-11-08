using System;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.Seeding.SeedDb
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class SeedDbCommandHandler : IRequestHandler<SeedDbCommand>
    {
        private readonly IEntryTypeRepository _entryTypeRepository;
        private readonly IUserTypeRepository _userTypeRepository;

        [IntentManaged(Mode.Ignore)]
        public SeedDbCommandHandler(IEntryTypeRepository entryTypeRepository,
                                    IUserTypeRepository userTypeRepository)
        {
            _entryTypeRepository = entryTypeRepository;
            _userTypeRepository = userTypeRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(SeedDbCommand request,
                                       CancellationToken cancellationToken)
        {
            await _entryTypeRepository.SeedEntryTypeAsync(cancellationToken);
            await _userTypeRepository.SeedUserTypeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}