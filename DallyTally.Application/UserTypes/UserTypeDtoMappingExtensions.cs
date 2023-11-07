using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using DallyTally.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace DallyTally.Application.UserTypes
{
    public static class UserTypeDtoMappingExtensions
    {
        public static UserTypeDto MapToUserTypeDto(this UserType projectFrom, IMapper mapper)
        {
            return mapper.Map<UserTypeDto>(projectFrom);
        }

        public static List<UserTypeDto> MapToUserTypeDtoList(this IEnumerable<UserType> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToUserTypeDto(mapper)).ToList();
        }
    }
}