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

        [HttpGet]
        public async Task<string> Get()
        {
            return await Mediator.Send(new GetTokenQuery());
        }
    }
}
