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
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        NorthwndContext context = new();
        Supplier supplier = context.Suppliers.FirstOrDefault(y=>y.SupplierId == id);
        if(supplier == null)
        {
            return BadRequest("Böyle bir Supplier bulunamadı!");
        }
        context.Suppliers.Remove(supplier);
        context.SaveChanges();
        return Ok("Kayıt başarılı");
    }
    [HttpPut]
    public IActionResult Put(Supplier supplier)
    {
        NorthwndContext context= new NorthwndContext();
        Supplier supplier1 = context.Suppliers.FirstOrDefault(x=>x.SupplierId==supplier.SupplierId);
        if(supplier1 == null)
        {
            return BadRequest("Böyle bir Supplier bulunamadı !");
        }
        supplier1.ContactName = supplier.ContactName;
        supplier1.CompanyName = supplier.CompanyName;
        supplier1.Address = supplier.Address;
        supplier1.ContactTitle = supplier.ContactTitle;
        supplier1.Phone = supplier.Phone;
        context.SaveChanges();
        return Ok("Kayıt başarılı");
    }
}
