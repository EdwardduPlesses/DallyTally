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
    public class EntryTypeRepository : RepositoryBase<EntryType, EntryType, ApplicationDbContext>, IEntryTypeRepository
    {
        public EntryTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<EntryType> FindByIdAsync(Guid id,
                                                   CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<EntryType>> FindByIdsAsync(Guid[] ids,
                                                          CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }


        public async Task SeedEntryTypeAsync(CancellationToken cancellationToken)
        {
            await AddEntryTypeSeed(new EntryType
            {
                Type = EntryTypeEnum.Guess,
                Description = "User guess for a DallyTally"
            }, cancellationToken);

            await AddEntryTypeSeed(new EntryType
            {
                Type = EntryTypeEnum.Actual,
                Description = "Actual result for a DallyTally"
            }, cancellationToken);
        }

        private async Task AddEntryTypeSeed(EntryType entryType,
                                            CancellationToken cancellationToken)
        {
            var existingEntryType = await FindAsync(x => x.Type == entryType.Type, cancellationToken);
            if (existingEntryType is not null)
            {
                existingEntryType.Type = entryType.Type;
                existingEntryType.Description = entryType.Description;
            }
            else
            {
                Add(entryType);
            }
        }
    }
}