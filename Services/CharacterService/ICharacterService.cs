using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharecters();
        Character GetCharacterById(int id);
        List<Character> AddCharecter (Character newCharacter);
 
    }
}