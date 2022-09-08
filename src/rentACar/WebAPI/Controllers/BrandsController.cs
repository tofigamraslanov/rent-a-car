using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand command)
        {
            CreatedBrandDto createdBrandDto = await Mediator?.Send(command)!;
            return Created("", createdBrandDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery query = new() { PageRequest = pageRequest };
            BrandListModel brands = await Mediator?.Send(query)!;
            return Ok(brands);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery query)
        {
            BrandGetByIdDto brandGetByIdDto = await Mediator?.Send(query)!;
            return Ok(brandGetByIdDto);
        }
    }
}