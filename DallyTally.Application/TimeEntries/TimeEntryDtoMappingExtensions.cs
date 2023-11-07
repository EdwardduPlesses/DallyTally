using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using DallyTally.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace DallyTally.Application.TimeEntries
{
    public static class TimeEntryDtoMappingExtensions
    {
        public static TimeEntryDto MapToTimeEntryDto(this TimeEntry projectFrom, IMapper mapper)
        {
            return mapper.Map<TimeEntryDto>(projectFrom);
        }

        public static List<TimeEntryDto> MapToTimeEntryDtoList(this IEnumerable<TimeEntry> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToTimeEntryDto(mapper)).ToList();
        }
    }
}