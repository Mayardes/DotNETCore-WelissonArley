using Microsoft.AspNetCore.Mvc;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;

namespace MyBookOfRecipes.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserResponseDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(RegisterUserRequestDTO request)
        {
            return Created();
        }
    }
}
