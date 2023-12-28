using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Chareacter;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.CharacterService;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
       
        // public static List<Character> characters = new List<Character>{
        //     new Character(),
        //     new Character{ID = 1,Name="Niraj"},
        //     new Character{ ID=2,Name="Raj"},
        //     new Character{ID=3,Name="Raju"},
        //     new Character{ID=4, Name="Nilesh"}
        // };
        private readonly ICharacterService _characterService;
         public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok(await _characterService.GetAllCharecters());
        }

        // [HttpGet]
        // public ActionResult<Character> GetSingle(){
        //     return Ok(_characterService.);
        // }
        
        [HttpGet("{id}")]

        public  async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }
        
        [HttpPost]
        public  async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
           
            return Ok(await _characterService.AddCharecter(newCharacter));
        }

        [HttpPut]
        public  async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updateCharacter){
           var response =await _characterService.UpdateCharecter(updateCharacter);
           if(response.Data is null){
            return NotFound(response);
           }
            return Ok(response);
        }

        [HttpDelete("{id}")]

        public  async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id){
              var response =await _characterService.DelatCharecters(id);
           if(response.Data is null){
            return NotFound(response);
           }
            return Ok(response);
        }
    }
}