using AutoMapper;
using BlazorBattles.Server.Entities;
using BlazorBattles.Server.Extensions;
using BlazorBattles.Shared;
using BlazorBattles.Shared.DTOs;
using BlazorBattles.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("user-info")]
        public async Task<ActionResult<UserDto>> GetCurrentUserInfo()
        {
            var user = await _userManager.GetCurrentUser(User);

            if (user == null) return NotFound("User not found");

            return _mapper.Map<UserDto>(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Result<UserDto>>> Register(UserRegister registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.NormalizedUserName == registerDto.UserName.ToUpper()))
                return BadRequest(Result<UserDto>.Fail("Username already exists."));

            var user = _mapper.Map<AppUser>(registerDto);

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest(Result<UserDto>.Fail(result.Errors.Select(e => e.Description).FirstOrDefault()));

            var roleResult = await _userManager.AddToRoleAsync(user, RoleNames.Member);

            if (!roleResult.Succeeded)
                return BadRequest(Result<UserDto>.Fail(roleResult.Errors.Select(e => e.Description).FirstOrDefault()));

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(Result<UserDto>.Success(userDto));
        }
    }
}
