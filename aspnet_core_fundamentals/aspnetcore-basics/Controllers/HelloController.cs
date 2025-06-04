using aspnetcore_basics.Interface;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_basics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ISaudacaoService _service;

        public HelloController(ISaudacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get() => _service.ObterMensagem();
    }
}
