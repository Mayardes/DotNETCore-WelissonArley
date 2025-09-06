using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBookOfRecipes.Application.DTO.Request.User.GetUser;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;
using MyBookOfRecipes.Application.Services.UserServices;

namespace MyBookOfRecipes.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserResponseDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromServices] IRegisterUserService registerUserService, RegisterUserRequestDTO request)
        {
            var result = await registerUserService.RegisterAsync(request);

            return Created($"v1/user/User?id={result.Id}", result);
        }

        [HttpGet]
        public async Task<IActionResult>GetUser([FromServices]IRegisterUserService registerUserService, [FromQuery] GetUserRequestDTO request)
        {
            var result = await registerUserService.GetUserAsync(request);
            return Ok(result);
        }
    }
}
