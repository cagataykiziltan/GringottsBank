using GringottsBank.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GringottsBank.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult GetActionResult<T>(this ControllerBase controllerBase, HttpResponseObject<T> result)  where T : class
        {
            if (result.Status == (int)HttpStatusCode.NoContent)
            {
                return new NoContentResult();
            }

            return new ObjectResult(result)
            {
                StatusCode = result.Status
            };
        }
    }
}
