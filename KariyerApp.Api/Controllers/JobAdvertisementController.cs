using AutoMapper;
using KariyerApp.Api.Dtos;
using KariyerApp.BusinessLogic.Interfaces;
using KariyerApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KariyerApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobAdvertisementController : ControllerBase
    {
        private readonly IJobAdvertisementService _jobAdvertisementService;
        private readonly IMapper _mapper;

        public JobAdvertisementController(IJobAdvertisementService jobAdvertisementService, IMapper mapper)
        {
            _jobAdvertisementService = jobAdvertisementService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateJobAdvertisementRequest request)
        {
            // Request modelini JobAdvertisement entity'sine dönüştürme
            var jobAdvertisement = _mapper.Map<JobAdvertisement>(request);

            var createdJobAdvertisement = await _jobAdvertisementService.CreateJobAdvertisementAsync(jobAdvertisement);

            return CreatedAtAction(nameof(Create), new { id = createdJobAdvertisement.Id }, createdJobAdvertisement);
        }

        [HttpGet("by-days/{days}")]
        public async Task<ActionResult<List<JobAdvertisement>>> GetByDays(int days)
        {
            var advertisements = await _jobAdvertisementService.GetJobAdvertisementsByDaysAsync(days);

            if (advertisements == null || !advertisements.Any())
            {
                return NotFound("No job advertisements found for the given number of days.");
            }

            return Ok(advertisements);
        }
    }
}
