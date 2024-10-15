using AutoMapper;
using Yobzh.Business.Interfaces;
using Yobzh.Business.Models;
using Yobzh.Data;
using Yobzh.Data.Entities;

namespace Yobzh.Business.Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{ 
    private IUnitOfWork unitOfWork { get; } = unitOfWork;

    private IMapper mapper { get; } = mapper;

    public void Add(ProductDto product)
    {
        unitOfWork.ProductRepository.Add(mapper.Map<Product>(product));
        unitOfWork.SaveChanges();
    }

    public void Update(ProductDto product)
    {
        unitOfWork.ProductRepository.Update(mapper.Map<Product>(product));
        unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    { 
        unitOfWork.ProductRepository.Delete(id);
        unitOfWork.SaveChanges();
    }

    public ProductDto GetById(int id)
    { 
        return mapper.Map<ProductDto>(unitOfWork.ProductRepository.GetById(id));
    }

    public List<ProductDto> GetAll()
    {
        return unitOfWork.ProductRepository.GetAll().Select(mapper.Map<ProductDto>).ToList();
    }
}
