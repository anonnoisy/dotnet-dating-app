using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/<:id>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(value => value.Id == id);
            return Ok(value);
        }
    }
}