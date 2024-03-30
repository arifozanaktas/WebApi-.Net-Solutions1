using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSolutions1.Models;

namespace WebApiSolutions1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public List<Product> GetAll()
    {
        NorthwndContext context = new NorthwndContext();
        List<Product> products = context.Products.ToList();
        return products;
    }

    [HttpGet("{id}")]
    public Product Get(int id)
    {
        NorthwndContext context= new NorthwndContext();
        Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
        return product;
    }
}
