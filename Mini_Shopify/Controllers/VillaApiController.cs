using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Shopify.Data;
using Mini_Shopify.Models;
using Mini_Shopify.Models.Dto;

namespace Mini_Shopify.Controllers
{
    [Route("api/villa")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ILogger<VillaApiController> _logger;
        private readonly ApplicationDbContext _context;
        public VillaApiController(ILogger<VillaApiController> logger,ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _logger = logger;
        }

        [HttpGet(Name = "GetVillas")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO[]))]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas() {
            _logger.LogInformation("Getting all Villas");

            return Ok(await _context.Villas.ToListAsync()) ;
        
        }
        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get Villa Error with  Id " + id);
                return BadRequest();
            }
            var villa =  await (_context.Villas.FirstOrDefaultAsync(u => u.Id == id));
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< ActionResult<VillaDTO>>CreateVilla([FromBody]VillaCreateDTO villa) {
            if (await _context.Villas.FirstOrDefaultAsync(v=> v.Name.ToLower() == villa.Name.ToLower()) != null) {
                ModelState.AddModelError("CustomError", "Villa is already exist");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest(villa);
            }
            Villa model = new() { 
                Amenity = villa.Amenity,
                Details= villa.Details,
                ImageUrl=villa.ImageUrl,
                Name=villa.Name,
                Occupancy=villa.Occupancy,
                Rate=villa.Rate,
                sqft=villa.Sqft
            };
            await _context.Villas.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetVilla",new {id= model.Id},villa);
        }



        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public async Task<IActionResult> DeleteVilla(int id)
        {

            if (id ==0)
            {
                return BadRequest();
            }
            var villa = await _context.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null) { return NotFound(); }
            _context.Villas.Remove(villa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody] VillaUpdateDTO villaDto)
        {

            if (villaDto == null || villaDto.Id != id)
            {
                return BadRequest();
            }
            Villa model = new()
            {
                Amenity = villaDto.Amenity,
                Details = villaDto.Details,
                Id = villaDto.Id,
                ImageUrl = villaDto.ImageUrl,
                Name = villaDto.Name,
                Occupancy = villaDto.Occupancy,
                Rate = villaDto.Rate,
                sqft = villaDto.Sqft
            };
            _context.Villas.Update(model);
            _context.SaveChanges();
            return NoContent();
        }



        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDto)
        {

            if (patchDto == null || id ==0)
            {
                return BadRequest();
            }
            var villa =await _context.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            VillaUpdateDTO villaDto = new() { 
                Amenity=villa.Amenity,
                Details=villa.Details,
                Id=villa.Id,
                ImageUrl=villa.ImageUrl,
                Name=villa.Name,
                Occupancy=villa.Occupancy,
                Rate=villa.Rate,Sqft=villa.sqft
            };

            patchDto.ApplyTo(villaDto, ModelState);

            Villa model = new()
            {
                Amenity = villaDto.Amenity,
                Details = villaDto.Details,
                Id = villaDto.Id,
                ImageUrl = villaDto.ImageUrl,
                Name = villaDto.Name,
                Occupancy = villaDto.Occupancy,
                Rate = villaDto.Rate,
                sqft = villaDto.Sqft
            };
            _context.Update(model);
            await _context.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
