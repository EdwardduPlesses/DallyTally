using System;
using System.Collections.Generic;
using AutoMapper;
using DallyTally.Application.Common.Mappings;
using DallyTally.Domain;
using DallyTally.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace DallyTally.Application.EntryTypes
{

    public class EntryTypeDto : IMapFrom<EntryType>
    {
        public EntryTypeDto()
        {
        }

        public static EntryTypeDto Create(
            Guid id,
            EntryTypeEnum type,
            string description)
        {
            return new EntryTypeDto
            {
                Id = id,
                Type = type,
                Description = description,
            };
        }

        public Guid Id { get; set; }

        public EntryTypeEnum Type { get; set; }

        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EntryType, EntryTypeDto>();
        }
    }
}