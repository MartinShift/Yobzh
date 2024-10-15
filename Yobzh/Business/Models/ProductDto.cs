namespace Yobzh.Business.Models;

public record ProductDto
{
    public int? Id { get; init; }

    public string Name { get; init; }

    public string? Description { get; init; }

    public double Price { get; init; }
}
