using System.Diagnostics.CodeAnalysis;

namespace ShopVerse.Demos;
public class Demo
{
    [NotNull]
    public Guid Id { get; set; }
    public string Name { get; set; }
}