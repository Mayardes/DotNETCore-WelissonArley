using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;
using MyBookOfRecipes.Application.Services.UserServices;

namespace MyBookOfRecipes.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController(IRegisterUserService registerUserService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserResponseDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(RegisterUserRequestDTO request)
        {
            var result = registerUserService.RegisterAsync(request);

            return Created($"v1/user/User?id={result.Id}", result);
        }

        [HttpGet]
        public async Task<IActionResult>GetUser(Guid id)
        {
            return Ok();
        }
    }
}
