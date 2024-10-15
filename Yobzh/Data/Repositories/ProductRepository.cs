using Yobzh.Data.Entities;
using Yobzh.Data.Interfaces;

namespace Yobzh.Data.Repositories;

public class ProductRepository(YobzhContext context) : IProductRepository
{
    private YobzhContext _context { get; } = context;

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product) 
    {
        _context.Products.Update(product);
    }

    public void Delete(int id)
    {
        var product = GetById(id);
        _context.Products.Remove(product);
    }

    public Product GetById(int id) 
    { 
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }
}
