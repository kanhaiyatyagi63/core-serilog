using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeriLogger.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IResult GetError()
        {
            _logger.LogDebug("I am in get error method!");
            try
            {
                string str = string.Empty;
                var getValue = str[3];
                return  Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Created by user", ex);
                return Result.Fail(ex.Message);
            }
           
        }
        [HttpGet("getbloblist")]
        public Result<List<string>> Tesing()
        {
            List<string> lst = new List<string>();
            lst.Add("Result1");
            lst.Add("Result2");

            lst.Add("Result3");
            lst.Add("Result4");

            var ff = Result<List<string>>.Success(lst);
            return ff;
        }
    }
}
