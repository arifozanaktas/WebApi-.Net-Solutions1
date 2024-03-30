using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSolutions1.Models;

namespace WebApiSolutions1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        NorthwndContext context = new NorthwndContext();
        List<Supplier> suppliers = context.Suppliers.ToList();
        return Ok(suppliers);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        NorthwndContext ctx = new NorthwndContext();
        Supplier supplier = ctx.Suppliers.FirstOrDefault(x=>x.SupplierId == id);
        if(supplier == null)
        {
            return BadRequest("Böyle bir Supplier mevcut değil!!");
        }
        return Ok(supplier);
    }
}
