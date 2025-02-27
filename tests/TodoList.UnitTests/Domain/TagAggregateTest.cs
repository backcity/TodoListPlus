namespace TodoList.UnitTests.Domain;

public class TagAggregateTest
{
    [Theory]
    [InlineData("test")]
    [InlineData("123")]
    [InlineData("321698")]
    [InlineData("#12")]
    [InlineData("#12345")]
    public void Create_tagcolor_item_with_TodoListPlusException(string value)
    {
        //Arrange
        TagColor tagColor;

        //Act


        //Assert
        Assert.Throws<TodoListPlusException>(() =>
        {
            tagColor = new TagColor(value);
        });
    }

    [Theory]
    [InlineData("#123")]
    [InlineData("#123456")]
    public void Create_tagcolor_item_with_no_TodoListPlusException(string value)
    {
        //Arrange
        TagColor tagColor;

        //Act
        tagColor = new TagColor(value);

        //Assert
        Assert.NotNull(tagColor);
    }
}
