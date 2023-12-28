using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Chareacter;
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
        private readonly IMapper _mapper;

        public CharecterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharecter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.ID = characters.Max(c => c.ID) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DelatCharecters(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{ 
           
            var character = characters.First(c => c.ID ==id);
            if(character is null){
                throw new Exception($"Chareacter with id '{id}' not found.");
            }
           characters.Remove(character);
           

           serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message =ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharecters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var Character = characters.FirstOrDefault(c => c.ID == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharecter(UpdateCharacterDto updateCharacter)
        {   var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try{ 
           
            var character = characters.FirstOrDefault(c => c.ID == updateCharacter.ID);
            if(character is null){
                throw new Exception($"Chareacter with id '{updateCharacter.ID}' not found.");
            }
            _mapper.Map<Character>(updateCharacter);
            character.Name = updateCharacter.Name;
            character.HitPoints = updateCharacter.HitPoints;
            character.Strength = updateCharacter.Strength;
            character.Defense = updateCharacter.Defense;
            character.Intelligence = updateCharacter.Intelligence;
            
           

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message =ex.Message;
            }
            return serviceResponse;

        }
    }
}