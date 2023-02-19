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

        /// <summary>
        /// Get all contracts
        /// </summary>
        /// <returns> Return IEnumerable<EquipmentPlacementContractDto/> </returns>
        /// <responce code="200">Success</responce>
        /// <responce code="401">Unautorized</responce> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IEnumerable<EquipmentPlacementContractDto>> Get()
        {
            return await Mediator.Send(new GetEquipmentPlacementContractQuery());
        }

        /// <summary>
        /// Add a contract if there is enough area
        /// </summary>
        /// <returns> Return AppActionResult </returns>
        /// <responce code="200"> AppActionResult.Success = true / false. </responce>
        /// <responce code="401">Unautorized</responce> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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