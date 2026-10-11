using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Request;
using MyRecipeBook.Communication.Response;

namespace MyRecipeBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody]RequestRegisterUserJson request, [FromServices]IRegisterUserUseCase useCase)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
