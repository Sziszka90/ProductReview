using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Application.Abstraction.Services;
using ProductReview.Application.Dtos.ProductDtos;

namespace ProductReview.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductStorageService _productStorageService;
    public ProductsController(IProductStorageService productStorageService)
    {
        _productStorageService = productStorageService;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductDto createProductDto)
    {
        var response = await _productStorageService.AddProduct(createProductDto);
        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpDelete("{category}/{productName}")]
    public async Task<IActionResult> DeleteProduct(string category, string productName)
    {
        var response = await _productStorageService.DeleteProduct(category, productName);
        return StatusCode(response.Status, response.Content);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var products = await _productStorageService.GetProducts(pageSize, pageNumber);
        return Ok(products);
    }
}

