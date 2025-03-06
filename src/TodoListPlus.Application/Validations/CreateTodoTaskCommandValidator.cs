using FluentValidation;
using TodoListPlus.Application.Command;

namespace TodoListPlus.Application.Validations;

public class CreateTodoTaskCommandValidator : AbstractValidator<CreateTodoTaskCommand>
{
    public CreateTodoTaskCommandValidator(ILogger<CreateTodoTaskCommandValidator> logger)
    {
        RuleFor(command => command.Title).NotEmpty();
        RuleFor(command => command.TaskContent).NotEmpty();
        RuleFor(command => command.SubTime).NotEmpty().Must(BeValidExpirationDate).WithMessage("Please specify a valid sub date");
        RuleFor(command => command.TaskTagItems).Must(ContainTaskTagItem).WithMessage("No tag items found");

        if (logger.IsEnabled(LogLevel.Trace))
        {
            logger.LogTrace("INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }

    private bool BeValidExpirationDate(DateTime dateTime)
    {
        return dateTime >= DateTime.Now;
    }

    private bool ContainTaskTagItem(IEnumerable<TaskTagDto> taskTagItems)
    {
        return taskTagItems.Any();
    }
}
