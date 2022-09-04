using Devs.Application.Features.Languages.Commands.CreateLanguage;
using Microsoft.AspNetCore.Mvc;
using Devs.Application.Features.Languages.Dtos;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }
    }
}
