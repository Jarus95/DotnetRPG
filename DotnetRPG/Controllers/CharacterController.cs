using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        public ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto character)
        {
            return Ok(await _characterService.AddCharacter(character));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharaterDto updatecharacter)
        {
            var response = await _characterService.UpdateCharacter(updatecharacter);

            if (response.Data == null)
                return NotFound(response);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<List<ServiceResponse<GetCharacterDto>>>> DeleteCharacter([FromRoute] int id)
        {
            var response = await _characterService.DeleteCharacter(id);

            if (response.Data == null)
                return NotFound(response);

            return Ok();
        }
    }
}
