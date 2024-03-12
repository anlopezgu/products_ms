using Microsoft.AspNetCore.Mvc;
using products_ms.Models;
using products_ms.Repositories;

namespace products_ms.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductRepository productRepository;
    public ProductController(ProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }



    [HttpGet("{id}")] 
    public IActionResult GetProduct(string id)
    {
        Product productFromFirebase = productRepository.Get(new Product()
        {
            Id = id
        });

        if (productFromFirebase == null)
        {
            return NotFound();
        }
        return Ok(productFromFirebase);
    }


    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        Product newProduct = productRepository.Add(product);
        if (newProduct == null)
            return BadRequest();
        return Ok(newProduct);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePodruct(string id)
    {
        if (productRepository.Delete(new Product()
        {
            Id = id
        }))
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpPut]
    public IActionResult UpdatePodruct(Product product)
    {
        Product productFromFirebase = productRepository.Get(new Product()
        {
            Id = product.Id
        });

        if (productFromFirebase == null)
            return NotFound();

        if (productRepository.Update(product))
            return Ok();
        return BadRequest();
    }
}