using cleanarch.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using SmartTestTask.CQRS.EquipmentPlacementContract.Commands.Create;

namespace SmartTestTask.Controllers
{
    public class EquipmentPlacementContractController : ApiControllerBase
    {
        public EquipmentPlacementContractController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> PostContract([FromBody] CreateEquipmentPlacementContractCommand command)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
    }
}