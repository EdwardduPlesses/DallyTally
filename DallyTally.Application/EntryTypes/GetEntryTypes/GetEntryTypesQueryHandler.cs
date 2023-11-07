using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace DallyTally.Application.EntryTypes.GetEntryTypes
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetEntryTypesQueryHandler : IRequestHandler<GetEntryTypesQuery, List<EntryTypeDto>>
    {
        private readonly IEntryTypeRepository _entryTypeRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetEntryTypesQueryHandler(IEntryTypeRepository entryTypeRepository, IMapper mapper)
        {
            _entryTypeRepository = entryTypeRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<EntryTypeDto>> Handle(GetEntryTypesQuery request, CancellationToken cancellationToken)
        {
            var entryTypes = await _entryTypeRepository.FindAllAsync(cancellationToken);
            return entryTypes.MapToEntryTypeDtoList(_mapper);
        }
    }
}