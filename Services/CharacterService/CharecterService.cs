using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services.CharacterService
{
    public class CharecterService : ICharacterService
    {
         public static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ID = 1,Name="Niraj"},
            new Character{ ID=2,Name="Raj"},
            new Character{ID=3,Name="Raju"},
            new Character{ID=4, Name="Nilesh"}
        };
        public List<Character> AddCharecter(Character newCharacter)
        {
             characters.Add(newCharacter);
            return characters;
        }

        public List<Character> GetAllCharecters()
        {
              return characters;
        }

        public Character GetCharacterById(int id)
        {
            var Character = characters.FirstOrDefault(c=>c.ID == id);
            if(Character is not null){
               return Character;
            }
            throw new Exception("Character is not found");
             
        }
    }
}