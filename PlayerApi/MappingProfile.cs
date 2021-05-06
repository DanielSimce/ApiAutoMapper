using AutoMapper;
using PlayerApi.Dto;
using PlayerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerApi
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDto>().ForMember(
                dest => dest.NameSimo,
                src => src.MapFrom(x => x.Name)
                ); 



            CreateMap<PlayerDto, Player>().ForMember(
                dest => dest.Name,
                src => src.MapFrom(x => x.NameSimo)
                );

            

        }
    }
}
