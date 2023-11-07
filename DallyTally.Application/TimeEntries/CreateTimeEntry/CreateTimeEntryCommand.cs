using System;
using System.Collections.Generic;
using DallyTally.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace DallyTally.Application.TimeEntries.CreateTimeEntry
{
    public class CreateTimeEntryCommand : IRequest<Guid>, ICommand
    {
        public DateTimeOffset EntryDate { get; set; }

        public DateTimeOffset Date { get; set; }

        public Guid UserId { get; set; }

        public Guid EntryTypeId { get; set; }

    }
}