using Application.Features.Brands.Commands.CreateBrand;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommand command)
        {
            var response = await Mediator?.Send(command)!;
            return Created("", response);
        }
    }
}
