using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace DallyTally.Application.UserTypes.GetUserTypeById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetUserTypeByIdQueryHandler : IRequestHandler<GetUserTypeByIdQuery, UserTypeDto>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetUserTypeByIdQueryHandler(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<UserTypeDto> Handle(GetUserTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var userType = await _userTypeRepository.FindByIdAsync(request.Id, cancellationToken);
            return userType.MapToUserTypeDto(_mapper);
        }
    }
}