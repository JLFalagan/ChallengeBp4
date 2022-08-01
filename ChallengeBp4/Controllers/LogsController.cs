using ChallengeBp4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBp4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public LogsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        [HttpGet("GetAllLogs")]
        public IActionResult GetAll()
        {
            var list = dbContext.LogData.ToList();
            return Ok(list);
        }
    }
}
