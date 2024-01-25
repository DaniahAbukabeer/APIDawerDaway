using APIDawerDaway.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDawerDaway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserProductController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("user-products")]
        public async Task<ActionResult<IEnumerable<UserProductDto>>> GetUserProducts()
        {
            try { 
            
            var userProducts = await _context.UserProduct
                .Include(up => up.product)
                .ToListAsync();

                var userProductDtos = userProducts.Select(up => new UserProductDto
                {
                    UserId = up.UserId,
                    ProductId = up.ProductId,
                    IsFavorite = up.IsFavorite,
                    Product = new SimpleProductDto { tName = up.product?.TName }, // Set the product name
                    ViewedAt = up.ViewedAt
                }).ToList();

                return userProductDtos;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
