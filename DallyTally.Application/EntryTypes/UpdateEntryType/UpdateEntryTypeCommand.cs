using System;
using System.Collections.Generic;
using DallyTally.Application.Common.Interfaces;
using DallyTally.Domain;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace DallyTally.Application.EntryTypes.UpdateEntryType
{
    public class UpdateEntryTypeCommand : IRequest, ICommand
    {
        public Guid Id { get; set; }

        public EntryTypeEnum Type { get; set; }

        public string Description { get; set; }

    }
}