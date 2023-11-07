using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace DallyTally.Application.TimeEntries.UpdateTimeEntry
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateTimeEntryCommandValidator : AbstractValidator<UpdateTimeEntryCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateTimeEntryCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
        }
    }
}