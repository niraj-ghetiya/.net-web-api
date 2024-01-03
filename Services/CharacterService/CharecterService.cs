using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Chareacter;
using Microsoft.EntityFrameworkCore;
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
        private readonly DataContext _context;

        public CharecterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharecter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            // character.ID = characters.Max(c => c.ID) + 1;
             _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            // await _context.Characters.Add(character);
            serviceResponse.Data =   _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DelatCharecters(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{ 
            var character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.ID == id );
            
            if(character is null){
                throw new Exception($"Chareacter with id '{id}' not found.");
            }
           _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
           

           serviceResponse.Data =  _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
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
            var dbChareacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbChareacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
              try{ 
            var Character =  await _context.Characters.FirstOrDefaultAsync(c => c.ID == id);
            if(Character is null){
                throw new Exception($"Chareacter with id '{id}' not found.");
            }
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(Character);
            } catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message =ex.Message;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharecter(UpdateCharacterDto updateCharacter)
        {   var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try{ 
           
            var character =  await _context.Characters.FirstOrDefaultAsync(c => c.ID == updateCharacter.ID);
            if(character is null){
                throw new Exception($"Chareacter with id '{updateCharacter.ID}' not found.");
            }
            _mapper.Map<Character>(updateCharacter);
            character.Name = updateCharacter.Name;
            character.HitPoints = updateCharacter.HitPoints;
            character.Strength = updateCharacter.Strength;
            character.Defense = updateCharacter.Defense;
            character.Intelligence = updateCharacter.Intelligence;
            
           
            await _context.SaveChangesAsync();  
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