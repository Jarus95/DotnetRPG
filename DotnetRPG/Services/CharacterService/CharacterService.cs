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
        public async Task<List<Character>> GetAllCharacters()
        {
            return characters;
        }
        public async Task<Character> GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id)!;
        }
        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }
    }
}
