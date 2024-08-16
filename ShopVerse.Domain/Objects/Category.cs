using System.Diagnostics.CodeAnalysis;

public class Category
{
    [NotNull]
    public Guid Id { get; set; }
    [NotNull]
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ParentCategoryID { get; set; }
}