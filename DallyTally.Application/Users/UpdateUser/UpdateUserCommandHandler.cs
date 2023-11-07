using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.Users.UpdateUser
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.FindByIdAsync(request.Id, cancellationToken);
            existingUser.Name = request.Name;
            existingUser.Surname = request.Surname;
            existingUser.Username = request.Username;
            existingUser.UserTypeId = request.UserTypeId;
            return Unit.Value;
        }
    }
}