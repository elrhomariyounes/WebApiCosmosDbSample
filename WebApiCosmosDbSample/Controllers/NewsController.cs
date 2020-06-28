using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCosmosDbSample.Models;
using WebApiCosmosDbSample.Services;

namespace WebApiCosmosDbSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost("news")]
        public async Task<IActionResult> AddNewsAsync([FromBody] NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _newsService.AddNewsAsync(model.Body, model.PhotoUrl);
                if (response != null)
                    return Ok(response);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest("Invalid Request");
        }

        [HttpGet("news")]
        public async Task<IActionResult> GetNewsAsync()
        {
            if (ModelState.IsValid)
            {
                var response = await _newsService.GetAllNewsAsync();
                if (response != null)
                    return Ok(response);
                return NotFound("No data found !!");
            }

            return BadRequest("Invalid Request");
        }

        [HttpGet("news/{id}")]
        public async Task<IActionResult> GetNewsByIdAsync([FromRoute] Guid id)
        {
            if (ModelState.IsValid)
            {
                var response = await _newsService.GetNewsByIdAsync(id);
                if (response != null)
                    return Ok(response);
                return NotFound("No data found !!");
            }

            return BadRequest("Invalid Request");
        }
    }
}
