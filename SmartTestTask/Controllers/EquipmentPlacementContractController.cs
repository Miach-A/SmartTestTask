using cleanarch.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using SmartTestTask.Common.Models;
using SmartTestTask.CQRS.EquipmentPlacementContract.Commands.Create;

namespace SmartTestTask.Controllers
{
    public class EquipmentPlacementContractController : ApiControllerBase
    {
        public EquipmentPlacementContractController()
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