using AutoMapper;
using BusinessObject.Dtos;
using BusinessObject.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UsersController(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.userRepository = new UserRepository();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                return Ok(mapper.Map<UserDto>(await userRepository.GetUsersAsync()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            try
            {
                var result = await userManager.FindByIdAsync(id);
                return result != null ? Ok(mapper.Map<UserDto>(result)) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync([FromBody] CreateUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var user = mapper.Map<User>(dto);
                await userManager.CreateAsync(user, dto.Password);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            var e = await userManager.FindByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            await userManager.DeleteAsync(e);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAsync(string id, [FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (dto.Id != id)
            {
                return BadRequest();
            }

            var e = await userManager.FindByIdAsync(id);
            if (e == null)
            {
                return NotFound();
            }
            await userManager.UpdateAsync(mapper.Map<User>(dto));
            return NoContent();
        }
    }
}
