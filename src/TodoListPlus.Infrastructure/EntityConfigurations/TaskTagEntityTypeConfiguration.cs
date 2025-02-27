namespace TodoListPlus.Infrastructure.EntityConfigurations
{
    class TaskTagEntityTypeConfiguration : IEntityTypeConfiguration<TaskTag>
    {
        public void Configure(EntityTypeBuilder<TaskTag> taskTagConfiguration)
        {
            taskTagConfiguration.ToTable("tasktags");

            taskTagConfiguration.HasKey(p => new { p.TodoTaskId, p.TagId });

            taskTagConfiguration
                .HasOne(t => t.Tag)
                .WithMany()
                .HasForeignKey(t => t.TagId)
                .OnDelete(DeleteBehavior.Restrict);

            taskTagConfiguration
                .Property(t => t.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()");
        }
    }
}
