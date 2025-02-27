

namespace TodoListPlus.Infrastructure.EntityConfigurations;

class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> tagConfiguration)
    {
        tagConfiguration.ToTable("tags");

        tagConfiguration.Ignore(t => t.DomainEvents);

        tagConfiguration.Property(t => t.Id)
            .UseHiLo("tasktagseq");

        tagConfiguration
            .OwnsOne(t => t.TagColor);

    }
}
