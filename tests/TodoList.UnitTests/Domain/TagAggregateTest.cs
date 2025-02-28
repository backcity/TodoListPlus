namespace TodoList.UnitTests.Domain;

public class TagAggregateTest
{
    [Theory]
    [InlineData("test")]
    [InlineData("123")]
    [InlineData("321698")]
    [InlineData("#12")]
    [InlineData("#12345")]
    public void create_tagcolor_item_with_TodoListPlusException(string value)
    {
        //Arrange
        TagColor tagColor;

        //Act


        //Assert
        Assert.Throws<TodoListPlusDomainException>(() =>
        {
            tagColor = new TagColor(value);
        });
    }

    [Theory]
    [InlineData("#123")]
    [InlineData("#123456")]
    public void create_tagcolor_item_with_no_TodoListPlusException(string value)
    {
        //Arrange
        TagColor tagColor;

        //Act
        tagColor = new TagColor(value);

        //Assert
        Assert.NotNull(tagColor);
    }

    [Fact]
    public void create_tag_item_success()
    {
        //Arrange
        string name = "日常";
        string colorStr = "#123";

        //Act
        var fakeTag = new Tag(name, colorStr);

        //Assert
        Assert.NotNull(fakeTag);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    public void create_tag_item_method_expiration_fail(string name)
    {
        //Arrange
        var colorStr = "#123";

        //Act - Assert
        Assert.Throws<TodoListPlusDomainException>(() => new Tag(name, colorStr));
    }


}
