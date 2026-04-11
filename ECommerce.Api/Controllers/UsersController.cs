using ECommerce.Api.CustomExtensions;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IResult> GetUsers() => this.ApiResponse(await userService.GetUsers());

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetUserById(Guid id) => this.ApiResponse(await userService.GetUserById(id));


         [HttpGet("role/{userRole}")]
        public async Task<IResult> GetUserByRole(string userRole) => this.ApiResponse(await userService.GetUserByRole(userRole));

        [HttpGet("email/{email}")]
        public async Task<IResult> GetUserByEmail(string email) => this.ApiResponse(await userService.GetUserByEmail(email));


        [HttpPut("{userStatus}/{id}")]
        public async Task<IResult> UpdateUserStatus(UserStatus userStatus,Guid id) => this.ApiResponse(await userService.UpdateUserStatus(userStatus,id));
    }
}
