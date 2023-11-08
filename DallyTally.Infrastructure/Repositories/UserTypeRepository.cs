using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DallyTally.Domain;
using DallyTally.Domain.Entities;
using DallyTally.Domain.Repositories;
using DallyTally.Infrastructure.Persistence;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace DallyTally.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UserTypeRepository : RepositoryBase<UserType, UserType, ApplicationDbContext>, IUserTypeRepository
    {
        public UserTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserType> FindByIdAsync(Guid id,
                                                  CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<UserType>> FindByIdsAsync(Guid[] ids,
                                                         CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }

        public async Task SeedUserTypeAsync(CancellationToken cancellationToken)
        {
            await AddUserTypeSeed(new UserType
            {
                Type = UserTypeEnum.User,
                Description = "Normal User that can make guesses"
            }, cancellationToken);
            await AddUserTypeSeed(new UserType
            {
                Type = UserTypeEnum.Admin,
                Description = "Admin User that can manage the DallyTally and make Guesses"
            }, cancellationToken);
        }

        private async Task AddUserTypeSeed(UserType userType,
                                           CancellationToken cancellationToken)
        {
            var existingUserType = await FindAsync(x => x.Type == userType.Type, cancellationToken);
            if (existingUserType is not null)
            {
                existingUserType.Type = userType.Type;
                existingUserType.Description = userType.Description;
            }
            else
            {
                Add(userType);
            }
        }
    }
}