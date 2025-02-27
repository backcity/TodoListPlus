

namespace TodoListPlus.Infrastructure;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, TodoListPlusDbContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(p => p.Entity.DomainEvents != null && p.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(p => p.Entity.ClearDomainEvents());

        foreach (var item in domainEvents)
        {
            await mediator.Publish(item);
        }
    }
}
