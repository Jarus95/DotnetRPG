using DotnetRPG.Models;
using DotnetRPG.Services.CharacterService;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<Character>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character character)
        {
            return Ok(await _characterService.AddCharacter(character));
        }
    }
}
