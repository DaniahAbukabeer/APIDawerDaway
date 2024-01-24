using APIDawerDaway.Models;
using APIDawerDaway.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDawerDaway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(AppDbContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //[HttpGet(Name ="GetProducts")]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        //{
        //    try
        //    {

        //        var Products = await _context.Products
        //            .Include(x => x.PharmaysProducts)
        //            .ToListAsync();

        //        var response = Products.Select(x => new
        //        {
        //            id = x.Id,
        //            tName = x.TName,
        //            categorie = x.Categorie,
        //            publicPrice = x.PharmaysProducts != null ?
        //            x.PharmaysProducts
        //            .Where(xx => xx.ProductId == x.Id)
        //            .Select(xx => xx.PublicPrice)
        //            .First()
        //            : new double()

        //        }) ;





        //        //var withExtendedInfo
        //        return CreatedAtAction(nameof(response), response);
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogError(ex, "Error getting all produtcs");
        //        return StatusCode(500, "internal server error");
        //    }
        //}

        //[HttpGet(Name = "GetProducts")]
        //public async Task<ActionResult<IEnumerable<object>>> GetProduct()
        //{
        //    try
        //    {
        //        var products = await _context.Products
        //            .Include(x => x.PharmaysProducts)
        //            .ToListAsync();

        //        if (products.Any())
        //        {

        //            var response = products.Select(x => new
        //            {
        //                id = x.Id,
        //                tName = x.TName,
        //                categorie = x.Categorie,
        //                publicPrice = x.PharmaysProducts != null ?
        //                    x.PharmaysProducts
        //                        .Where(xx => xx.ProductId == x.Id)
        //                        .Select(xx => xx.PublicPrice)
        //                        .FirstOrDefault() ?? 0.0
        //                    : 0.0
        //            });

        //            return Ok(response);
        //        }
        //        else
        //            return BadRequest("couldnt get products");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        //_logger.LogError(ex, "Error getting all products");
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}
        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<MergedProductsVM>>> GetProduct()
        {
            try
            {
                var query = _context.Products
                    .Include(c => c.PharmaysProducts)
                    .OrderBy(c => c.Id);

                var queryString = query.ToQueryString();
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(queryString);


                //var products = await _context.Products
                //    .Include(x => x.PharmaysProducts)
                //    .ToListAsync();

                var products = await query.ToListAsync();

                var response = products.Select(MergedProductsVM.FromProduct);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }


}
