

using TodoListPlus.Infrastructure;

namespace TodoListPlus.Api.Extensions;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        // 添加身份认证 依赖注入
        services.AddIdentityServices(builder.Configuration);

        services.AddDbContext<TodoListPlusDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("todolistdb"));
        });

        services.AddHttpContextAccessor();
        services.AddTransient<ILoggedInUserService, LoggedInUserService>();

        // Configure mediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(CreateTodoTaskCommand));

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionBehaior<,>));
        });

        // 注册命令验证器 
        services.AddSingleton<IValidator<CreateTodoTaskCommand>, CreateTodoTaskCommandValidator>();

        //
        services.AddScoped<ITodoTaskQueries, TodoTaskQueries>();
        services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
        services.AddScoped<ITaskTagRepository, TaskTagRepository>();

    }

    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapHealthChecks("/health");

            app.MapHealthChecks("alive", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live")
            });
        }
        return app;
    }
}
