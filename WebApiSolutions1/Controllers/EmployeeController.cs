using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSolutions1.Models;

namespace WebApiSolutions1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        NorthwndContext context = new NorthwndContext();
        List<Employee> employees = context.Employees.ToList();
        return Ok(employees);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        NorthwndContext context=new NorthwndContext();
        Employee employee = context.Employees.FirstOrDefault(x=>x.Id == id);
        if (employee == null)
        {
            return BadRequest("Böyle bir Employee bulunamadı!");
        }
        return Ok(employee);
    }
}
