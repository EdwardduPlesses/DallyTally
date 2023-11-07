using System;
using System.Collections.Generic;
using DallyTally.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace DallyTally.Application.UserTypes.DeleteUserType
{
    public class DeleteUserTypeCommand : IRequest, ICommand
    {
        public Guid Id { get; set; }

    }
}