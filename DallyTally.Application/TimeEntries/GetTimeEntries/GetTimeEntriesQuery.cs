using System;
using System.Collections.Generic;
using DallyTally.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace DallyTally.Application.TimeEntries.GetTimeEntries
{
    public class GetTimeEntriesQuery : IRequest<List<TimeEntryDto>>, IQuery
    {
    }
}