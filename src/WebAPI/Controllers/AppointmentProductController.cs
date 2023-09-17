using Application.Features.AppointmentProducts.Commands.CreateAppointmentProduct;
using Application.Features.AppointmentProducts.Commands.UpdateAppointmentProduct;
using Application.Features.AppointmentProducts.Dtos;
using Application.Features.AppointmentProducts.Models;
using Application.Features.AppointmentProducts.Queries.GetListAppointmentProduct;
using Application.Features.AppointmentProducts.Queries.GetListAppointmentProductByDynamic;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentProductsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAppointmentProductCommand createAppointmentProductCommand)
        {
            CreateAppointmentProductDto result = await Mediator.Send(createAppointmentProductCommand);
            return Created("", result);
        }




        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListAppointmentProductByDynamicQuery getListByDynamicQuery = new GetListAppointmentProductByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            AppointmentProductListModel result = await Mediator.Send(getListByDynamicQuery);
            return Ok(result);

        }



        [HttpPost("GetList/All")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListAppointmentProductQuery getListQuery = new GetListAppointmentProductQuery { PageRequest = pageRequest };
            AppointmentProductListModel result = await Mediator.Send(getListQuery);
            return Ok(result);

        }



        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromQuery] UpdateAppointmentProductCommand updateAppointmentProductCommand)
        {
            UpdateAppointmentProductDto result = await Mediator.Send(updateAppointmentProductCommand);
            return Ok(result);

        }

    }
}

