using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using DallyTally.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace DallyTally.Application.EntryTypes
{
    public static class EntryTypeDtoMappingExtensions
    {
        public static EntryTypeDto MapToEntryTypeDto(this EntryType projectFrom, IMapper mapper)
        {
            return mapper.Map<EntryTypeDto>(projectFrom);
        }

        public static List<EntryTypeDto> MapToEntryTypeDtoList(this IEnumerable<EntryType> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToEntryTypeDto(mapper)).ToList();
        }
    }
}