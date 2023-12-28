using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Chareacter;
using Models;

namespace Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharecters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharecter (AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharecter (UpdateCharacterDto updateCharacter);
         Task<ServiceResponse<List<GetCharacterDto>>> DelatCharecters(int id);
         
 
    }
}