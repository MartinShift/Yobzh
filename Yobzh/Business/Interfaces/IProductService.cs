using Yobzh.Business.Models;

namespace Yobzh.Business.Interfaces;

public interface IProductService
{
    void Add(ProductDto product);

    void Update(ProductDto product);

    void Delete(int id);

    ProductDto GetById(int id);

    List<ProductDto> GetAll();
}
