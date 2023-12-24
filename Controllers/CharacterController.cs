using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        public static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ID = 1,Name="Niraj"},
            new Character{ ID=2,Name="Raj"},
            new Character{ID=3,Name="Raju"},
            new Character{ID=4, Name="Nilesh"}
        };
        
        [HttpGet("GetAll")]
        public ActionResult<List<Character>>Get(){
            return Ok(characters);
        }

        [HttpGet]
        public ActionResult<Character> GetSingle(){
            return Ok(characters[1]);
        }
        
        [HttpGet("{id}")]

        public ActionResult<Character> GetSingle(int id){
            return Ok(characters.FirstOrDefault(c=>c.ID == id));
        }
        
    }
}