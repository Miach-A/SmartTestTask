using cleanarch.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartTestTask.CQRS.Auth.Queries;

namespace SmartTestTask.Controllers
{
    public class Auth : ApiControllerBase
    {
        public Auth(ISender mediator) : base(mediator)
        {
        }
        /// <summary>
        /// Get free token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> Get()
        {
            return await Mediator.Send(new GetTokenQuery());
        }
    }
}
