using System.Linq;
using System.Threading.Tasks;
using BaltaShop.Products.Data;
using BaltaShop.Products.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaltaShop.Products.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAsync([FromServices] ShopDataContext context)
        {
            var products = await context
                .Products
                .AsNoTracking()
                .Where(x => x.Active)
                .ToListAsync();

            return Ok(products);
        }

        [HttpPost("")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateProductViewModel model,
            [FromServices] ShopDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = model.ToProduct();
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return Created("", model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            int id,
            [FromBody] UpdateProductViewModel model,
            [FromServices] ShopDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return NotFound();

            model.Update(product);
            context.Products.Update(product);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            int id,
            [FromServices] ShopDataContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return NotFound();

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
