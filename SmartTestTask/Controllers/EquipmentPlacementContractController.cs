using cleanarch.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTestTask.Common.Models;
using SmartTestTask.CQRS.EquipmentPlacementContracts.Commands.Create;
using SmartTestTask.CQRS.EquipmentPlacementContracts.Queries.GetEquipmentPlacementContract;

namespace SmartTestTask.Controllers
{
    [Authorize]
    public class EquipmentPlacementContractController : ApiControllerBase
    {
        public EquipmentPlacementContractController(ISender mediator) : base(mediator) { }
        [HttpGet]
        public async Task<IEnumerable<EquipmentPlacementContractDto>> Get()
        {
            return await Mediator.Send(new GetEquipmentPlacementContractQuery());
        }

        [HttpPost]
        public async Task<ActionResult<AppActionResult>> Post([FromBody] CreateEquipmentPlacementContractCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
    }
}