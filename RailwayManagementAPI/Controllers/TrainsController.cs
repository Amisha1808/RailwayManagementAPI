using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RailwayManagementAPI.Models;
using RailwayManagementAPI.Services;

namespace RailwayManagementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly ITrainService _trainService;

        public TrainsController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrains()
        {
            var trains = await _trainService.GetAllTrains();
            return Ok(trains);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainById(int id)
        {
            var train = await _trainService.GetTrainById(id);
            if (train == null)
                return NotFound();

            return Ok(train);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTrain(Train train)
        {
            var addedTrain = await _trainService.AddTrain(train);
            return CreatedAtAction(nameof(GetTrainById), new { id = addedTrain.Id }, addedTrain);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTrain(int id, Train train)
        {
            if (id != train.Id)
                return BadRequest();

            var updatedTrain = await _trainService.UpdateTrain(train);
            if (updatedTrain == null)
                return NotFound();

            return Ok(updatedTrain);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            var result = await _trainService.DeleteTrain(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}