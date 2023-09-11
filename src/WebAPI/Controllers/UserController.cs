using Application.Features.Auths.Commands.CreateUser;
using Application.Features.Auths.Commands.UpdateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetListUser;
using Application.Features.Users.Queries.GetListUserByDynamic;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
        {
            var result = await Mediator.Send(createUserCommand);
            return Created("", result);
        }




        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListUserByDynamicQuery getListByDynamicQuery = new GetListUserByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            UserListModel result = await Mediator.Send(getListByDynamicQuery);
            return Ok(result);

        }



        [HttpPost("GetList/All")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListQuery = new GetListUserQuery { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(getListQuery);
            return Ok(result);

        }



        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromQuery] UpdateUserCommand updateUserCommand)
        {
            var result = await Mediator.Send(updateUserCommand);
            return Ok(result);

        }

    }
}

