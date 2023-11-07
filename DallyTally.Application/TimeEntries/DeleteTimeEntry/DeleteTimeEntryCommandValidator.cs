using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace DallyTally.Application.TimeEntries.DeleteTimeEntry
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteTimeEntryCommandValidator : AbstractValidator<DeleteTimeEntryCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public DeleteTimeEntryCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
        }
    }
}