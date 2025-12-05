using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            IList<Customer> customers = await context.Customers.ToListAsync();
            return Ok(new {Success = true, Data = customers});
            // return Ok(new {Success = true, StatusCode = 200, Items=customers.Count, Page=1, Pages=5, Data = customers}); 
            // Standarden för att returnera data i REST api är 2 delar, 1 som talar om att det är success/godkänt, 
            // det andra är själva objektdatan. Man kan även sätta vilken sida som ska visas och hur många sidor det är. 
            // Om man vill vara övertydlig kan man även skriva statuskoden man får
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(int id)
        {
            Customer? customer = await context.Customers.FindAsync(id);
            
            if (customer is null) return NotFound();
            return Ok(new {Success = true, Data = customer});
        }
    }
}
