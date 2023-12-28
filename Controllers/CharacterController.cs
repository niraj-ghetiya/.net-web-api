using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<List<Character>>Get(){
            return Ok(_characterService.GetAllCharecters());
        }

        // [HttpGet]
        // public ActionResult<Character> GetSingle(){
        //     return Ok(_characterService.);
        // }
        
        [HttpGet("{id}")]

        public ActionResult<Character> GetSingle(int id){
            return Ok(_characterService.GetCharacterById(id));
        }
        
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter){
           
            return Ok(_characterService.AddCharecter(newCharacter));
        }
    }
}