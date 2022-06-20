using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SharedKernel.WebAPI.Controllers
{
    /// <summary>Base controller</summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        /// <summary>
        /// MediatR instance
        /// </summary>
        protected IMediator Mediator => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>())
                                        ?? throw new InvalidOperationException($"{nameof(IMediator)} not registered", new NotImplementedException(nameof(IMediator)));
    }
}