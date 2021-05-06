using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayerApi.Dto;
using PlayerApi.Models;
using PlayerApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public ServiceController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public ActionResult<PlayerDto> Post(PlayerDto playerDto)
        {
            _playerService.Add(playerDto);          

            return Ok(playerDto);
        }

        [HttpPut]
        public ActionResult<PlayerDto> Put(PlayerDto playerDto)
        {
            _playerService.Update(playerDto);
            _playerService.Save();

            return Ok(playerDto);
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<Player> Delete(int id)
        {
            var player = _playerService.GetPlayer(id);
            _playerService.Delete(player);
            _playerService.Save();

            return Ok(player);

            
        }

       
        [HttpGet]
        public ActionResult<IEnumerable<PlayerDto>> All()
        {
            return Ok(_playerService.AllPlayerDtos());
        }


        [Route("{id}")]
        [HttpGet]
        public ActionResult<PlayerDto> PlayerById(int id)
        {
            
            return Ok(_playerService.PlayerDtoById(id));
        }
    }
}
