﻿using Application.ExampleContext.Commands;
using Application.ExampleContext.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Infrastructure.WebApi.Controllers
{
    /// <inheritdoc />
    public class ExampleController : BaseController
    {
        /// <summary>Example GET</summary>
        /// <returns><see cref="ExampleQueryResult"/></returns>
        [HttpGet]
        public async Task<ActionResult<ExampleQueryResult>> GetAsync()
        {
            return Ok(await Mediator.Send(new ExampleQuery()));
        }

        /// <summary>Example POST</summary>
        /// <returns><see cref="ActionResult"/></returns>
        [HttpPost]
        public async Task<ActionResult> PostAsync()
        {
            return Ok(await Mediator.Send(new ExampleCommand()));
        }
    }
}