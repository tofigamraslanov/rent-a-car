using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery query = new(pageRequest);
            ModelListModel models = await Mediator?.Send(query)!;
            return Ok(models);
        }

        [HttpPost]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
            [FromBody] Dynamic dynamic)
        {
            GetListModelByDynamicQuery query = new(dynamic, pageRequest);
            ModelListModel models = await Mediator?.Send(query)!;
            return Ok(models);
        }
    }
}