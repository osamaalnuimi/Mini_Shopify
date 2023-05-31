using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Shopify.Entities.Data;
using Mini_Shopify.Entities.Models;
using Mini_Shopify.Entities.Models.Dto;
using Mini_Shopify.Entities.Repository.IRepository;

namespace Mini_Shopify.Controllers
{
    [Route("api/VillaNumber")]
    [ApiController]
    public class VillaNumberApiController : ControllerBase
    {
        private readonly ILogger<VillaNumberApiController> _logger;
        private readonly IRepositoryWrapper _repository;
       
        public VillaNumberApiController(ILogger<VillaNumberApiController> logger, IRepositoryWrapper repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet(Name = "GetVillaNumbers")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse<IEnumerable<VillaNumberDTO>>))]
        public ActionResult<APIResponse<IEnumerable<VillaNumberDTO>>> GetVillas() {
            _logger.LogInformation("Getting all Villas");
           
            var villasDto =  _repository.VillaNumber.GetAll().Select(v=> new VillaNumberDTO { VillaNo = v.VillaNo, SpecialDetails  = v.SpecialDetails}).ToList();
            return Ok(new APIResponse<IEnumerable<VillaNumberDTO>> { Data = villasDto, StatusCode = StatusCodes.Status200OK }) ;
        
        }
        [HttpGet("{id:int}",Name ="GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(VillaNumberDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public ActionResult<APIResponse<VillaNumberDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get Villa Error with  Id " + id);
                return BadRequest();
            }
            var villa =   _repository.VillaNumber.GetByCondition(u=> u.VillaNo == id).Select(v=> new VillaNumberDTO { VillaNo = v.VillaNo, SpecialDetails = v.SpecialDetails,VillaId = v.VillaID}).First();
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(new APIResponse<VillaNumberDTO> { Data = villa,StatusCode=StatusCodes.Status200OK });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VillaNumberCreateDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< ActionResult<VillaNumberCreateDTO>>CreateVilla([FromBody]VillaNumberCreateDTO villa) {
            if ( _repository.VillaNumber.GetByCondition(v=> v.VillaNo == villa.VillaNo).Any()) {
                ModelState.AddModelError("CustomError", "Villa is already exist");
                return BadRequest(ModelState);
            }
            if (_repository.Villa.GetByCondition(v=>v.Id == villa.VillaId).Any() == false)
            {
                ModelState.AddModelError("CustomError", "Villa Id is Invalid!");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest(villa);
            }
            VillaNumber model = new() {
                VillaNo = villa.VillaNo,
                VillaID = villa.VillaId,
                SpecialDetails = villa.SpecialDetails           
            };
            _repository.VillaNumber.Create(model);
            _repository.Save();

            return CreatedAtRoute("GetVillaNumber",new {id= model.VillaNo},villa);
        }



        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        public async Task<IActionResult> DeleteVilla(int id)
        {

            if (id ==0)
            {
                return BadRequest();
            }
            var villa = await _repository.VillaNumber.GetByCondition(u => u.VillaNo == id).FirstOrDefaultAsync();
            if (villa == null) { return NotFound(); }
            _repository.VillaNumber.Delete(villa);
             _repository.Save();
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        public IActionResult UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO villaDto)
        {

            if (villaDto == null || villaDto.VillaNo != id)
            {
                return BadRequest();
            }
            if (_repository.Villa.GetByCondition(v => v.Id == villaDto.VillaId).Any() == false)
            {
                ModelState.AddModelError("CustomError", "Villa Id is Invalid!");
                return BadRequest(ModelState);
            }
            VillaNumber model = new()
            {
               SpecialDetails = villaDto.SpecialDetails,
            };
            _repository.VillaNumber.Update(model);
            _repository.Save();
            return NoContent();
        }



        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id:int}", Name = "UpdatePartialVillaNumber")]
        public async Task<IActionResult> UpdatePartialVillaNumber(int id, JsonPatchDocument<VillaNumberUpdateDTO> patchDto)
        {

            if (patchDto == null || id ==0)
            {
                return BadRequest();
            }
            var villa =(VillaNumber)_repository.VillaNumber.GetByCondition(u => u.VillaNo == id);

            VillaNumberUpdateDTO villaDto = new() { 
               SpecialDetails = villa.SpecialDetails,
            };

            patchDto.ApplyTo(villaDto, ModelState);

            VillaNumber model = new()
            {
                SpecialDetails= villa.SpecialDetails,
            };
            _repository.VillaNumber.Update(model);
            _repository.Save();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
