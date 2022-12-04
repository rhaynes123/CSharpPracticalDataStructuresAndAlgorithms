using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergencyDispatch.Data;
using EmergencyDispatch.Features.Emergencies.Model;
using EmergencyDispatch.Features.Emergencies.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmergencyDispatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmergencyController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public EmergencyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        // GET: api/Emergency/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet(Name = "GetQueue")]
        public async Task<IActionResult> GetQueueAsync()
        {
            List<(Emergency, int)> results = _dbContext.Emergencies
                .Select(PrepareEmergency)
                .ToList();
            var queue = new PriorityQueue<Emergency, int>(results);
            await Task.CompletedTask;
            return Ok(queue.UnorderedItems);
        }

        // POST: api/Emergency
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReportAsync([FromBody] EmergencyRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("One or more required fields not provided");
            }
            var emergency = new Emergency
            {
                Address = request.Address
            };
            var addedEntity = await _dbContext.Emergencies.AddAsync(emergency);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = addedEntity.Entity.Id }, emergency);
        }

        // PUT: api/Emergency/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Emergency/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private (Emergency, int) PrepareEmergency(Emergency emergency)
        {
            return (emergency, (int)emergency.category);
        }
    }
}
