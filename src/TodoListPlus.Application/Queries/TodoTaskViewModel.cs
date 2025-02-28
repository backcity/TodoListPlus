namespace TodoListPlus.Application.Queries;

public record TodoTask
{
    public int TaskNumber { get; init; }
    public string Title { get; init; }
    public string TaskContent { get; init; }
    public DateTime Date { get; init; }
    public string IsDownOver { get; init; }
    public string Priority { get; init; }
    public List<Tag> Tags { get; init; }
}

public record Tag
{
    public string Name { get; init; }
    public string HexColor { get; init; }
}

