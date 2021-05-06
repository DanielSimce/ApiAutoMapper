using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayerApi.Dto;
using PlayerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public PlayersController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<PlayerDto> Post([FromBody] PlayerDto playerDto)
        {
            var player = _mapper.Map<PlayerDto, Player>(playerDto);
            _context.Players.Add(player);
            _context.SaveChanges();

            playerDto.Id = player.Id;

            return Ok(playerDto);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Player> GetById(int id)
        {
            var player = _context.Players.Find(id);

            return Ok(player);
        }

        [Route("Dto/{id}")]
        [HttpGet]
        public ActionResult<PlayerDto> GetByIdDto(int id)
        {
            var player = _context.Players.Find(id);

            

            return Ok(_mapper.Map<Player,PlayerDto>(player));
        }

        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            var players = _context.Players.ToList();


            return Ok(players);
        }

        [HttpGet("AllDto")]
        public ActionResult<List<PlayerDto>> GetAllDto()
        {

            return Ok(_context.Players.ToList().Select(_mapper.Map<Player, PlayerDto>));


        }

        [HttpPut]
        public ActionResult<PlayerDto> Put([FromBody] PlayerDto playerDto)
        {
            var player = _context.Players.Find(playerDto.Id);

            _mapper.Map(playerDto, player);

            _context.SaveChanges();

            return Ok(playerDto);
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<Player> Delete(int id)
        {
            var player = _context.Players.Find(id);
            _context.Players.Remove(player);
            _context.SaveChanges();

            return Ok(player);
        }
    }
}
