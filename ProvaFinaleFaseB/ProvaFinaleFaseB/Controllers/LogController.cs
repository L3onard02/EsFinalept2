using Microsoft.AspNetCore.Mvc;
using ProvaFinaleFaseB.Entities;
using ProvaFinaleFaseB.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaFinaleFaseB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ILogsRepository _logsRepository;
        public LogController(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }
        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogsEntity>> Get(string url)
        {
            return await _logsRepository.findLog(url);
        }

        
    }
}
