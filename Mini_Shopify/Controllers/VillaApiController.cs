using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Shopify.Entities.Data;
using Mini_Shopify.Entities.Models;
using Mini_Shopify.Entities.Models.Dto;
using Mini_Shopify.Entities.Repository.IRepository;

namespace Mini_Shopify.Controllers
{
    [Route("api/villa")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ILogger<VillaApiController> _logger;
        private readonly IRepositoryWrapper _repository;
       
        public VillaApiController(ILogger<VillaApiController> logger, IRepositoryWrapper repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet(Name = "GetVillas")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse<IEnumerable<VillaDTO>>))]
        public ActionResult<APIResponse<IEnumerable<VillaDTO>>> GetVillas() {
            _logger.LogInformation("Getting all Villas");
           
            var villasDto =  _repository.Villa.GetAll().Select(v=> new VillaDTO { Id = v.Id,Name=v.Name,Amenity=v.Amenity,Details=v.Details,ImageUrl=v.ImageUrl,Occupancy=v.Occupancy,Rate=v.Rate,Sqft=v.sqft }).ToList();
            return Ok(new APIResponse<IEnumerable<VillaDTO>> { Data = villasDto, StatusCode = StatusCodes.Status200OK }) ;
        
        }

        [Authorize(Roles ="admin")]
        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public ActionResult<APIResponse<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get Villa Error with  Id " + id);
                return BadRequest();
            }
            var villa =   _repository.Villa.GetByCondition(u=> u.Id == id).Select(v=> new VillaDTO { Id = v.Id, Name = v.Name, Amenity = v.Amenity, Details = v.Details, ImageUrl = v.ImageUrl, Occupancy = v.Occupancy, Rate = v.Rate, Sqft = v.sqft }).First();
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(new APIResponse<VillaDTO> { Data = villa,StatusCode=StatusCodes.Status200OK });
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< ActionResult<VillaDTO>>CreateVilla([FromBody]VillaCreateDTO villa) {
            if ( _repository.Villa.GetByCondition(v=> v.Name.ToLower() == villa.Name.ToLower()).Any()) {
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
            _repository.Villa.Create(model);
            _repository.Save();

            return CreatedAtRoute("GetVilla",new {id= model.Id},villa);
        }


        [Authorize(Roles ="Custom")]
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
            var villa = await _repository.Villa.GetByCondition(u => u.Id == id).FirstOrDefaultAsync();
            if (villa == null) { return NotFound(); }
            _repository.Villa.Delete(villa);
             _repository.Save();
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
            _repository.Villa.Update(model);
            _repository.Save();
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
            var villa =(Villa)_repository.Villa.GetByCondition(u => u.Id == id);

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
            _repository.Villa.Update(model);
            _repository.Save();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
