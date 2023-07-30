using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;

namespace DotnetRPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        public static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character()
            {
                Id = 3,
                Name = "Sam",
            }
        };

        public readonly IMapper mapper;

        public CharacterService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c=> mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c=>c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data =  characters.Select(c=>mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

       
    }
}
