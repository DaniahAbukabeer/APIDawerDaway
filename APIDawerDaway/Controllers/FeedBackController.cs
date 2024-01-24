using APIDawerDaway.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDawerDaway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly ILogger<FeedBackController> _logger;
        private readonly AppDbContext _context;

        public FeedBackController(ILogger<FeedBackController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet(Name = "GetFeedbacks")]
        public IEnumerable<FeedBack> Get()
        {
            // Implement logic to get all feedbacks from the database
            // Example using Entity Framework Core:
            var feedbacks = _context.FeedBacks.ToList();
            return feedbacks;
        }

    }

}
