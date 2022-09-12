using Devs.Application.Features.Languages.Commands.CreateLanguage;
using Microsoft.AspNetCore.Mvc;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Queries.GetListLanguage;
using Devs.Application.Features.Languages.Models;
using Core.Application.Requests;
using Devs.Application.Features.Languages.Queries.GetByIdLanguage;
using Devs.Application.Features.Languages.Commands.UpdateLanguage;
using Devs.Application.Features.Languages.Commands.DeleteLanguage;
using FluentValidation;

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

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetId([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            var languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(languageGetByIdDto);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdatedLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        {
            DeletedLanguageDto result = await Mediator.Send(deleteLanguageCommand);
            return Ok(result);
        }
    }
}
