using Microsoft.AspNetCore.Mvc;
using Yobzh.Business.Interfaces;
using Yobzh.Business.Models;

namespace Yobzh.Controllers;

[ApiController]
[Route("/products")]
public class ProductsController(IProductService productService) : ControllerBase
{
    private IProductService productService = productService;

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(productService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(productService.GetById(id));
    }

    [HttpPost]
    public IActionResult Add(ProductDto product)
    {
        productService.Add(product);
        return Ok(product);
    }

    [HttpPut]
    public IActionResult Update(ProductDto product)
    {
        productService.Update(product);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        productService.Delete(id);
        return Ok();
    }

}
