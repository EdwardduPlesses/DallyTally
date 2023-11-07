using System;
using System.Collections.Generic;
using AutoMapper;
using DallyTally.Application.Common.Mappings;
using DallyTally.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace DallyTally.Application.TimeEntries
{

    public class TimeEntryDto : IMapFrom<TimeEntry>
    {
        public TimeEntryDto()
        {
        }

        public static TimeEntryDto Create(
            Guid id,
            DateTimeOffset entryDate,
            DateTimeOffset date,
            Guid userId,
            Guid entryTypeId)
        {
            return new TimeEntryDto
            {
                Id = id,
                EntryDate = entryDate,
                Date = date,
                UserId = userId,
                EntryTypeId = entryTypeId,
            };
        }

        public Guid Id { get; set; }

        public DateTimeOffset EntryDate { get; set; }

        public DateTimeOffset Date { get; set; }

        public Guid UserId { get; set; }

        public Guid EntryTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TimeEntry, TimeEntryDto>();
        }
    }
}