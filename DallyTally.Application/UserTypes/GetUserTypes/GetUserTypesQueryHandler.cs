using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DallyTally.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace DallyTally.Application.UserTypes.GetUserTypes
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetUserTypesQueryHandler : IRequestHandler<GetUserTypesQuery, List<UserTypeDto>>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetUserTypesQueryHandler(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<UserTypeDto>> Handle(GetUserTypesQuery request, CancellationToken cancellationToken)
        {
            var userTypes = await _userTypeRepository.FindAllAsync(cancellationToken);
            return userTypes.MapToUserTypeDtoList(_mapper);
        }
    }
}