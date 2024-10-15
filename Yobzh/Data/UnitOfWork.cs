using Yobzh.Data.Interfaces;

namespace Yobzh.Data;

public class UnitOfWork(IProductRepository productRepository, YobzhContext context) : IUnitOfWork
{
    public IProductRepository ProductRepository { get; } = productRepository;

    private YobzhContext _context { get; } = context;

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
