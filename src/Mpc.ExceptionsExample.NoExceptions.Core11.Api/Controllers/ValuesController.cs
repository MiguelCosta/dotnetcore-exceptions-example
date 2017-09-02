namespace Mpc.ExceptionsExample.NoExceptions.Core11.Api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Mpc.ExceptionsExample.NoExceptions.Core11.Services;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IValuesService _valuesService;

        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<int> values)
        {
            var serviceResult = _valuesService.ProcessValues(values);
            if (!serviceResult.Success)
            {
                return BadRequest(serviceResult.Messages);
            }

            return Ok(serviceResult.Result);
        }
    }
}
