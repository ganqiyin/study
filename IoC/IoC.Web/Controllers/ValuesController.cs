using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoC.Application;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IoC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBackgroundService _backgroundService;
        private readonly ITService _tService;
        private readonly IUserAppService _userAppService;
        public ValuesController(IBackgroundService backgroundService, ITService tService, IUserAppService userAppService)
        {
            _backgroundService = backgroundService;
            _tService = tService;
            _userAppService = userAppService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string i = id switch
            {
                1 => _backgroundService.Singletion(),
                2 => _userAppService.Scoped(),
                _ => _tService.Traint(),
            };
            return i;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
