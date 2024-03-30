using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSolutions1.Models;

namespace WebApiSolutions1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        NorthwndContext context = new NorthwndContext();
        List<Category> categories = context.Categories.ToList();
        return Ok(categories);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        NorthwndContext context = new NorthwndContext();
        Category category = context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            return BadRequest("Böyle bir Category mevcut değil!!");
        }
        return Ok(category);
    }
}
