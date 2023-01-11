using BL;
using DL.Models;
using Microsoft.AspNetCore.Mvc;

namespace TableManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : Controller
    {
        public IBLColor BL;
        //public IMapper mapper;
        public ColorController(IBLColor BL)
        {
            this.BL = BL;
        }
        // GET: 
        [HttpGet()]
        public async Task<List<Color>> Get()
        {
           return await BL.getColors();
        }
        [HttpGet("{id}")]
        public async Task<Color> Get(int id)
        {
            return await BL.getColorById(id);
        }

        // POST 
        [HttpPost()]
        public async Task<ActionResult<Color>> Post([FromBody] Color color)
        {
            var newColor = await BL.createColor(color);
            if (newColor != null)
            {
                return Ok(newColor);
            }
            return NoContent();
        }
        //PUT 
        [HttpPut("{id}")]
        public async Task<Color> Put(int id, [FromBody] Color colorToUpdate)
        {
            return await BL.updateColor(id, colorToUpdate);
        }
        //DELETE
        [HttpDelete()]
        public async Task<Color> Delete(int id)
        {
            return await BL.deleteColor(id);
        }
    }
}
