
using TodoTask = TodoListPlus.Application.Queries.TodoTask;
using Tag = TodoListPlus.Application.Queries.Tag;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoListPlus.Api.Apis;
using Fx.SeedWork.EventBus.Extensions;

public static class TodoTaskApi
{
    public static RouteGroupBuilder MapOrdersApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/todotasks").HasApiVersion(1.0);


    }

    public static async Task<Results<Ok, BadRequest<string>>> CreateTodoTaskAsync(
        [FromHeader(Name = "x-requestid")] Guid requestId,
        CreateTodoTaskRequest request,
        [AsParameters] TodoTaskServices services)
    {
        services.Logger.LogInformation(
            "Sending command: {CommandName} - {IdProperty}: {CommandId}",
            request.GetGenericTypeName(),
            nameof(request.UserId),
            request.UserName);

        if (requestId == Guid.Empty)
        {
            services.Logger.LogWarning("Invalid IntegrationEvent - RequestId is missing - {@IntegrationEvent}", requestId);
            return TypedResults.BadRequest("RequestId is missing.");
        }

        using (services.Logger.BeginScope(new List<KeyValuePair<string,object>> { new KeyValuePair<string, object>("IdentifiedCommandId", requestId) }))
        {

        }
    }


    public record CreateTodoTaskRequest(
        string UserId,
        string UserName,
        string Title,
        string TaskContent,
        DateTime SubTime,
        Priority Priority,
        List<TaskTagDto> Items);

}
