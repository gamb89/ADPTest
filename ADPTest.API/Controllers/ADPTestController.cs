
using ADPTest.Application.Abstract;
using ADPTest.Application.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADPTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADPTestController : ControllerBase
    {
        private readonly IAdpTestService _service; 
        public ADPTestController(IAdpTestService service)
        {
            this._service = service; 
        }
        // GET: api/<ADPTestController>
        [HttpGet]
        public async Task<ResponseObjectDto> Get()
        {
            var result = await _service.ExecuteOperation(false);

            return result; 
        }

       
    }
}
