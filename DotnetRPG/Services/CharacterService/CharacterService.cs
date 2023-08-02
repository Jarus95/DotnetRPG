using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;
using Microsoft.AspNetCore.Mvc;

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
            serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
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
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharaterDto updateCharacterDto)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updateCharacterDto.Id);

                if (character == null)
                    throw new Exception($"Character whith {updateCharacterDto.Id} not found");

                var MapCharacter = mapper.Map(updateCharacterDto, character);
                serviceResponse.Data = mapper.Map<GetCharacterDto>(MapCharacter);

            }

            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter([FromRoute] int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try 
            {
               var character = characters.FirstOrDefault(c => c.Id == id);

               if (character == null)
                   throw new Exception($"Character whith {id} not found");

               characters.Remove(character);
               serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
                
            }

            catch(Exception ex) 
            { 
                serviceResponse.Succes=false;
                serviceResponse.Message = ex.Message;
            }


            return serviceResponse;
        }
    }
}
