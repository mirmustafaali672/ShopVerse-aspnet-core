namespace ShopVerse.Categories;
public class CategoryGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ParentCategoryID { get; set; }
}
public class CategoryCreateOrUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ParentCategoryID { get; set; }
}
public class CategoryGetListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentCategoryID { get; set; }
}


