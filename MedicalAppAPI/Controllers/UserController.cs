using AutoMapper;
using MedicalAppAPI.DTOs;
using MedicalAppAPI.Mapper;
using MedicalAppAPI.Models.Domains;
using MedicalAppAPI.Repos.UserActions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositoryActions _userRepositoryActions;
        private readonly IMapper _mapper;

        public UserController(IUserRepositoryActions userRepositoryActions, IMapper mapper)
        {
            _userRepositoryActions = userRepositoryActions;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserDto createUserDto)
        {
            var newUser = _mapper.Map<User>(createUserDto);
            newUser = await _userRepositoryActions.AddUserAsync(newUser);
            return CreatedAtAction(nameof(AddUser), newUser);
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllUsers([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var currentUsers = await _userRepositoryActions.GetAllUsersAsync(filterOn, filterQuery,
                pageNumber, pageSize);
            return Ok(_mapper.Map<List<User>>(currentUsers));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await _userRepositoryActions.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"No user found with ID {id}");
            }
            _mapper.Map<User>(user);
            return Ok(user);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] CreateUserDto updateUserDto)
        {
            var userToUpdate = await _userRepositoryActions.GetByIdAsync(id);

            if (userToUpdate == null)
            {
                return NotFound($"No user found with ID {id}");
            }
            _mapper.Map(updateUserDto, userToUpdate);

            var updatedUser = await _userRepositoryActions.UpdateUserAsync(id, userToUpdate);

            return Ok(updatedUser);
        }

    }
}
