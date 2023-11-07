using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.UserTypes.UpdateUserType
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateUserTypeCommandHandler : IRequestHandler<UpdateUserTypeCommand>
    {
        private readonly IUserTypeRepository _userTypeRepository;

        [IntentManaged(Mode.Ignore)]
        public UpdateUserTypeCommandHandler(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Unit> Handle(UpdateUserTypeCommand request, CancellationToken cancellationToken)
        {
            var existingUserType = await _userTypeRepository.FindByIdAsync(request.Id, cancellationToken);
            existingUserType.Type = request.Type;
            existingUserType.Description = request.Description;
            return Unit.Value;
        }
    }
}