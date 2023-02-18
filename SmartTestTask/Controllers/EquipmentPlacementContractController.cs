using cleanarch.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartTestTask.Common.Models;
using SmartTestTask.CQRS.EquipmentPlacementContracts.Commands.Create;

namespace SmartTestTask.Controllers
{
    public class EquipmentPlacementContractController : ApiControllerBase
    {
        public EquipmentPlacementContractController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<AppActionResult>> PostContract([FromBody] CreateEquipmentPlacementContractCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }
    }
}