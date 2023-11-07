using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain.Entities;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace DallyTally.Application.UserTypes.CreateUserType
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateUserTypeCommandHandler : IRequestHandler<CreateUserTypeCommand, Guid>
    {
        private readonly IUserTypeRepository _userTypeRepository;

        [IntentManaged(Mode.Ignore)]
        public CreateUserTypeCommandHandler(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Handle(CreateUserTypeCommand request, CancellationToken cancellationToken)
        {
            var newUserType = new UserType
            {
                Type = request.Type,
                Description = request.Description,
            };

            _userTypeRepository.Add(newUserType);
            await _userTypeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return newUserType.Id;
        }
    }
}