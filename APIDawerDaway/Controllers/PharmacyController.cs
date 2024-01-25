using APIDawerDaway.Models;
using APIDawerDaway.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace APIDawerDaway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PharmacyController(AppDbContext context)
        {
           _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int id)
        {
            try {

                //var pharmacies = await _context.pharmacies
                //    .Include(p => p.feedbacks)
                //    .Include(p => p.PharmaysProducts)
                //    .ToListAsync();

                var pharmacy = await _context.pharmacies
                    .Include(p => p.feedbacks)
                    .Include(p => p.PharmaysProducts)
                    .FirstOrDefaultAsync(p=>p.Id == id);
                if (pharmacy == null)
                {
                    return NotFound();
                }

                var jsonSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore                  
                };





                var jsonResult = JsonConvert.SerializeObject(pharmacy, jsonSettings);
                var result = JsonConvert.DeserializeObject<Pharmacy>(jsonResult);
                if(result!= null)
                     return result;
                else
                    return NotFound();
                //    var pharmacies = _context.pharmacies.ToListAsync();

                //return pharmacies;
                //var pharmacies = _context.pharmacies.ToListAsync();
                //var response = new { 
                    
                
                //};
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

            //var pharmacies = _context.pharmacies
            //    .Include(PharamcyProducts => PharamcyProducts.PharmaysProducts)

        [HttpGet]
        public async Task<ActionResult<PharmaciesResponseDto>> GetPharmacies()
        {
            var pharmacies = await _context.pharmacies
                .Include(p => p.feedbacks)
                .Include(p => p.PharmaysProducts)
                    .ThenInclude(pp=>pp.Product)
                .ToListAsync();



            var pharmacyDtos = pharmacies.Select(p => new PharmacyDto
            {
                Id = p.Id,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                Address = p.Address,
                Latitude = Convert.ToDouble(p.Latitude), // Convert if needed
                Longitude = Convert.ToDouble(p.Longitude), // Convert if needed
                Description = p.description,
                Open24Hours = p.Open24Hours,
                OpeningTime = p.OpeningTime,
                ClosingTime = p.ClosingTime,
                Rating = p.Rating,
                Feedbacks = p.feedbacks.Select(f => new FeedbackDto
                {
                    Statues = f.Statues,
                    Title = f.Title,
                    Text = f.Text,
                    Rating = f.Rating,
                    UserId = f.UserId,
                    PharmacyId = f.PharmacyId
                }).ToList(),
                Products = p.PharmaysProducts.Select(pp => new ProductDto
                {
                    Id = pp.ProductId,
                    TName = pp.Product?.TName ?? " ", // Replace with actual property name
                    SName = pp.Product?.SName ?? " ", // Replace with actual property name
                    UserId = pp.Product?.UserId ?? 0, // Replace with actual property name
                    Provider = pp.Product?.Provider ?? " ", // Replace with actual property name
                    Country = pp.Product?.Country, // Replace with actual property name
                    Dosage = pp.Product?.Dosage ?? 0, // Replace with actual property name
                    AtcCode = pp.Product?.ATCCODE ?? " ", // Replace with actual property name
                    Categorie = pp.Product?.Categorie ?? " ", // Replace with actual property name
                    PublicPrice = pp.PublicPrice,
                    Quantity = pp.Quantity,
                    Amount = pp.Amount ?? 0, // Replace with actual property name
                    PrivatePrice = pp.PrivatePrice,
                    PharmacyId = pp.PharmacyId,
                    ProductId = pp.ProductId
                }).ToList()
            }).ToList();

            var responseDto = new PharmaciesResponseDto
            {
                Pharmacies = pharmacyDtos
            };

            return responseDto;
        }
    }
}
