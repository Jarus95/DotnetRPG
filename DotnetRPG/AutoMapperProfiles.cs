using DotnetRPG.Dtos.Character;
using DotnetRPG.Models;

namespace DotnetRPG
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
