using System;
using System.Collections.Generic;
using DallyTally.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace DallyTally.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class TimeEntry : IHasDomainEvent
    {
        public Guid Id { get; set; }

        public DateTimeOffset EntryDate { get; set; }

        public DateTimeOffset Date { get; set; }

        public Guid UserId { get; set; }

        public Guid EntryTypeId { get; set; }

        public virtual User User { get; set; }

        public virtual EntryType EntryType { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}