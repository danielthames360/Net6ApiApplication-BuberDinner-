﻿using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                IServiceExpection serviceExpection => ((int)serviceExpection.StatusCode, serviceExpection.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error ocurred.")
            };

            return Problem(statusCode: statusCode, title: message);
        }
    }
}
