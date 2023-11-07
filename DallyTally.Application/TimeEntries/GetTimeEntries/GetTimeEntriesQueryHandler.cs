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

namespace DallyTally.Application.TimeEntries.GetTimeEntries
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetTimeEntriesQueryHandler : IRequestHandler<GetTimeEntriesQuery, List<TimeEntryDto>>
    {
        private readonly ITimeEntryRepository _timeEntryRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetTimeEntriesQueryHandler(ITimeEntryRepository timeEntryRepository, IMapper mapper)
        {
            _timeEntryRepository = timeEntryRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<TimeEntryDto>> Handle(GetTimeEntriesQuery request, CancellationToken cancellationToken)
        {
            var timeEntries = await _timeEntryRepository.FindAllAsync(cancellationToken);
            return timeEntries.MapToTimeEntryDtoList(_mapper);
        }
    }
}