using CoinSkill.Api.Contracts.Responses;
using CoinSkill.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoinSkill.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(u=> new UsersResponse(u.Id,u.UserName));
            return Ok(response);
        }
        //[HttpGet]
        //public async Task<ActionResult<UsersResponse>> GetByEmail()
        //{
        //    var
        //}



    }
}
