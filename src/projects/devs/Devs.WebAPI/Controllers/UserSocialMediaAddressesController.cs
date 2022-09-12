using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Devs.Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;
using Devs.Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;
using Devs.Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;
using Devs.Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress;
using Devs.Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress;
using Devs.Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddressByDynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediaAddressesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserSocialMediaAddressCommand createUserSocialMediaAddressCommand)
        {
            var result = await Mediator!.Send(createUserSocialMediaAddressCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserSocialMediaAddressCommand updateUserSocialMediaAddressCommand)
        {
            var result = await Mediator!.Send(updateUserSocialMediaAddressCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserSocialMediaAddressCommand deleteUserSocialMediaAddressCommand)
        {
            var result = await Mediator!.Send(deleteUserSocialMediaAddressCommand);
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserSocialMediaAddressQuery getByIdUserSocialMediaAddressQuery)
        {
            var result = await Mediator!.Send(getByIdUserSocialMediaAddressQuery);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserSocialMediaAddressQuery getListUserSocialMediaAddressQuery = new() { PageRequest = pageRequest };
            var result = await Mediator!.Send(getListUserSocialMediaAddressQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            var getListByDynamicUserSocialMediaAddressQuery = new GetListUserSocialMediaAddressByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator!.Send(getListByDynamicUserSocialMediaAddressQuery);
            return Ok(result);

        }
    }
}
