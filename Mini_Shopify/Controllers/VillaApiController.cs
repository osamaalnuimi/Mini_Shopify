using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Mini_Shopify.Data;
using Mini_Shopify.Models;
using Mini_Shopify.Models.Dto;

namespace Mini_Shopify.Controllers
{
    [Route("api/villa")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet(Name = "GetVillas")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO[]))]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas() {
            return Ok(VillaStore.villaList);
        
        }
        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = (VillaStore.villaList.FirstOrDefault(u => u.Id == id));
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
        public ActionResult<VillaDTO>CreateVilla([FromBody]VillaDTO villa) {
            if (VillaStore.villaList.FirstOrDefault(v=> v.Name.ToLower() == villa.Name.ToLower()) != null) {
                ModelState.AddModelError("CustomError", "Villa is already exist");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest(villa);
            }
            if (villa.Id > 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villa.Id = VillaStore.villaList.OrderByDescending(u => u.Id)
                                           .FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villa);
            return CreatedAtRoute("GetVilla",new {id= villa.Id},villa);
        }



        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {

            if (id ==0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null) { return NotFound(); }
            VillaStore.villaList.Remove(villa);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDto)
        {

            if (villaDto == null || villaDto.Id != id)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            
            villa.Name = villaDto.Name;
            villa.Sqft = villaDto.Sqft;
            villa.Occupancy = villaDto.Occupancy;
          
            return NoContent();
        }



        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDto)
        {

            if (patchDto == null || id ==0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);

            patchDto.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
