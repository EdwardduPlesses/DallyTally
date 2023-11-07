using System;
using System.Collections.Generic;
using DallyTally.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace DallyTally.Application.Users.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>, ICommand
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public Guid UserTypeId { get; set; }

    }
}