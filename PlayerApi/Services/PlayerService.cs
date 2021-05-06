using AutoMapper;
using PlayerApi.Dto;
using PlayerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerApi.Services
{
    public class PlayerService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public PlayerService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<PlayerDto> AllPlayerDtos()
        {
            return _context.Players.ToList().Select(_mapper.Map<Player,PlayerDto>);
        }

        public PlayerDto PlayerDtoById(int id)
        {
            var player = _context.Players.Find(id);

            return _mapper.Map<Player, PlayerDto>(player);
        }

        public void Add(PlayerDto playerDto)
        {
            var player = _mapper.Map<PlayerDto, Player>(playerDto);

            _context.Players.Add(player);
            this.Save();

            playerDto.Id = player.Id;
        }

        public void Update(PlayerDto playerDto)
        {
            var player = _mapper.Map<PlayerDto, Player>(playerDto);

            _context.Players.Update(player);
        }

        public void Delete(Player player)
        {
            
            _context.Players.Remove(player);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Player GetPlayer(int id)
        {
            return _context.Players.Find(id);
        }
       

    }
}
