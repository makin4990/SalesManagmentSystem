using Application.Features.Appointments.Commands.CreateAppointment;
using Application.Features.Appointments.Commands.UpdateAppointment;
using Application.Features.Appointments.Dtos;
using Application.Features.Appointments.Models;
using Application.Features.Appointments.Queries.GetListAppointment;
using Application.Features.Appointments.Queries.GetListAppointmentByDynamic;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;




[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAppointmentCommand createAppointmentCommand)
    {
        CreateAppointmentDto result = await Mediator.Send(createAppointmentCommand);
        return Created("", result);
    }




    [HttpPost("GetList/ByDynamic")]
    public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListAppointmentByDynamicQuery getListByDynamicQuery = new GetListAppointmentByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
        AppointmentListModel result = await Mediator.Send(getListByDynamicQuery);
        return Ok(result);

    }


    [HttpPost("GetList/All")]
    public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAppointmentQuery getListQuery = new GetListAppointmentQuery { PageRequest = pageRequest };
        AppointmentListModel result = await Mediator.Send(getListQuery);
        return Ok(result);

    }



    [HttpPost("Update")]
    public async Task<ActionResult> Update([FromQuery] UpdateAppointmentCommand updateAppointmentCommand)
    {
        UpdateAppointmentDto result = await Mediator.Send(updateAppointmentCommand);
        return Ok(result);

    }

}

