namespace TodoListPlus.Infrastructure.EntityConfigurations;


class TodoTaskEntityTypeConfiguration : IEntityTypeConfiguration<TodoTask>
{
    public void Configure(EntityTypeBuilder<TodoTask> taskConfiguration)
    {
        taskConfiguration.ToTable("todotasks");

        taskConfiguration.Ignore(p => p.DomainEvents);

        taskConfiguration.Property(p => p.Id)
            .UseHiLo("taskseq");

        taskConfiguration
            .Property(o => o.TodoTaskStatus)
            .HasConversion<string>()
            .HasMaxLength(30);

        taskConfiguration
            .Property(t => t.Priority)
            .HasConversion<string>()
            .HasMaxLength(30);


    }
}
