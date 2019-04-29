using GrabrReplica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrabrReplica.Persistance.Configurations
{
    public class DialogConfiguration : IEntityTypeConfiguration<Dialog>
    {
        public void Configure(EntityTypeBuilder<Dialog> builder)
        {
            builder.HasMany(p => p.Messages).WithOne(p => p.Dialog);
        }
    }
}