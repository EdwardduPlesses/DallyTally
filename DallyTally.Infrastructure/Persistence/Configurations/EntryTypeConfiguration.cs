using DallyTally.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace DallyTally.Infrastructure.Persistence.Configurations
{
    public class EntryTypeConfiguration : IEntityTypeConfiguration<EntryType>
    {
        public void Configure(EntityTypeBuilder<EntryType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}