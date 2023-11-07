using System;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.UserTypes.DeleteUserType
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteUserTypeCommandHandler : IRequestHandler<DeleteUserTypeCommand>
    {
        private readonly IUserTypeRepository _userTypeRepository;

        [IntentManaged(Mode.Ignore)]
        public DeleteUserTypeCommandHandler(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(DeleteUserTypeCommand request, CancellationToken cancellationToken)
        {
            var existingUserType = await _userTypeRepository.FindByIdAsync(request.Id, cancellationToken);
            _userTypeRepository.Remove(existingUserType);
            return Unit.Value;
        }
    }
}