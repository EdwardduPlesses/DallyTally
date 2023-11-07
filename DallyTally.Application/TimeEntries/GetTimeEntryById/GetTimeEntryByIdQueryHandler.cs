using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace DallyTally.Application.TimeEntries.GetTimeEntryById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetTimeEntryByIdQueryHandler : IRequestHandler<GetTimeEntryByIdQuery, TimeEntryDto>
    {
        private readonly ITimeEntryRepository _timeEntryRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetTimeEntryByIdQueryHandler(ITimeEntryRepository timeEntryRepository, IMapper mapper)
        {
            _timeEntryRepository = timeEntryRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<TimeEntryDto> Handle(GetTimeEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var timeEntry = await _timeEntryRepository.FindByIdAsync(request.Id, cancellationToken);
            return timeEntry.MapToTimeEntryDto(_mapper);
        }
    }
}