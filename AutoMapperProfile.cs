using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Chareacter;
using Models;

namespace _net_web_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character , GetCharacterDto>();
            CreateMap< AddCharacterDto , Character>();
            CreateMap<UpdateCharacterDto , Character>();
        }
    }
}