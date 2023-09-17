using Application.Features.Categorys.Commands.CreateCategory;
using Application.Features.Categorys.Commands.UpdateCategory;
using Application.Features.Categorys.Dtos;
using Application.Features.Categorys.Models;
using Application.Features.Categorys.Queries.GetListCategory;
using Application.Features.Categorys.Queries.GetListCategoryByDynamic;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreateCategoryDto result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }




        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListCategoryByDynamicQuery getListByDynamicQuery = new GetListCategoryByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            CategoryListModel result = await Mediator.Send(getListByDynamicQuery);
            return Ok(result);

        }



        [HttpPost("GetList/All")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCategoryQuery getListQuery = new GetListCategoryQuery { PageRequest = pageRequest };
            CategoryListModel result = await Mediator.Send(getListQuery);
            return Ok(result);

        }



        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromQuery] UpdateCategoryCommand updateCategoryCommand)
        {
            UpdateCategoryDto result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);

        }

    }
}

