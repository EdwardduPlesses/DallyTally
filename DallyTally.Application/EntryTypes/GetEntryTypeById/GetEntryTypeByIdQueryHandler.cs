using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace DallyTally.Application.EntryTypes.GetEntryTypeById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetEntryTypeByIdQueryHandler : IRequestHandler<GetEntryTypeByIdQuery, EntryTypeDto>
    {
        private readonly IEntryTypeRepository _entryTypeRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetEntryTypeByIdQueryHandler(IEntryTypeRepository entryTypeRepository, IMapper mapper)
        {
            _entryTypeRepository = entryTypeRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<EntryTypeDto> Handle(GetEntryTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var entryType = await _entryTypeRepository.FindByIdAsync(request.Id, cancellationToken);
            return entryType.MapToEntryTypeDto(_mapper);
        }
    }
}