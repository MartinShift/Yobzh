using Yobzh.Data.Interfaces;

namespace Yobzh.Data;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }

    void SaveChanges();
}
