

namespace TodoListPlus.Infrastructure.EntityConfigurations;

class TaskTagEntityTypeConfiguration : IEntityTypeConfiguration<TaskTag>
{
    public void Configure(EntityTypeBuilder<TaskTag> taskTagConfiguration)
    {
        taskTagConfiguration.ToTable("tasktags");

        taskTagConfiguration.Ignore(t => t.DomainEvents);

        taskTagConfiguration.Property(t => t.Id)
            .UseHiLo("tasktagseq");

        taskTagConfiguration
            .OwnsOne(t => t.TagColor);
    }
}
