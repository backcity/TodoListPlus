namespace TodoListPlus.Domain.AggregatesModel.TaskTagAggregate;

public class TagColor : ValueObject
{
    public string Value { get; private set; }

    public TagColor(string value)
    {
        //todo 判断颜色字符串是否符合规则
       /* if ()
        {
            throw new TodoListPlusException("不支持的颜色规则");
        }*/
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
