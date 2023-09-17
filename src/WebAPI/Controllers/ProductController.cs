using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Queries.GetListProduct;
using Application.Features.Products.Queries.GetListProductByDynamic;
using CoreFramework.Application.Requests;
using CoreFramework.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;



[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
    {
        CreateProductDto result = await Mediator.Send(createProductCommand);
        return Created("", result);
    }


    [HttpPost("GetList/ByDynamic")]
    public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListProductByDynamicQuery getListByDynamicQuery = new GetListProductByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
        ProductListModel result = await Mediator.Send(getListByDynamicQuery);
        return Ok(result);

    }


    [HttpPost("GetList/All")]
    public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuery getListQuery = new GetListProductQuery { PageRequest = pageRequest };
        ProductListModel result = await Mediator.Send(getListQuery);
        return Ok(result);

    }

    [HttpPost("Update")]
    public async Task<ActionResult> Update([FromQuery] UpdateProductCommand updateProductCommand)
    {
        UpdateProductDto result = await Mediator.Send(updateProductCommand);
        return Ok(result);

    }

}

