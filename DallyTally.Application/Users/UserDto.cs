using System;
using System.Collections.Generic;
using AutoMapper;
using DallyTally.Application.Common.Mappings;
using DallyTally.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace DallyTally.Application.Users
{

    public class UserDto : IMapFrom<User>
    {
        public UserDto()
        {
        }

        public static UserDto Create(
            Guid id,
            string name,
            string surname,
            string username,
            Guid userTypeId)
        {
            return new UserDto
            {
                Id = id,
                Name = name,
                Surname = surname,
                Username = username,
                UserTypeId = userTypeId,
            };
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public Guid UserTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>();
        }
    }
}