using System;
using System.Collections.Generic;
using AutoMapper;
using DallyTally.Application.Common.Mappings;
using DallyTally.Domain;
using DallyTally.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace DallyTally.Application.UserTypes
{

    public class UserTypeDto : IMapFrom<UserType>
    {
        public UserTypeDto()
        {
        }

        public static UserTypeDto Create(
            Guid id,
            UserTypeEnum type,
            string description)
        {
            return new UserTypeDto
            {
                Id = id,
                Type = type,
                Description = description,
            };
        }

        public Guid Id { get; set; }

        public UserTypeEnum Type { get; set; }

        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserType, UserTypeDto>();
        }
    }
}