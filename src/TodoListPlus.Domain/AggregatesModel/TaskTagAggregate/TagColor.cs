using System.Text.RegularExpressions;

namespace TodoListPlus.Domain.AggregatesModel.TaskTagAggregate;

public class TagColor : ValueObject
{
    public string Value { get; private set; }

    public TagColor(string value)
    {
        //todo 判断颜色字符串是否符合规则
        var flexibleRegex = new Regex(@"^#(?:[A-Fa-f0-9]{3}){1,2}$|^#(?:[A-Fa-f0-9]{4}){2}$");

        if (!flexibleRegex.IsMatch(value))
        {
            throw new TodoListPlusDomainException("不支持的颜色规则");
        }
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
