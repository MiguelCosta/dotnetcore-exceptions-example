namespace Mpc.ExceptionsExample.WithExceptions.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Mpc.ExceptionsExample.WithExceptions.Service;

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
            try
            {
                var serviceResult = _valuesService.ProcessValues(values);
                return Ok(serviceResult);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
