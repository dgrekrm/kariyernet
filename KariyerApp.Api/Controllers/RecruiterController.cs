using System.Threading.Tasks;
using AutoMapper;
using KariyerApp.Api.Dtos;
using KariyerApp.BusinessLogic.Interfaces;
using KariyerApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KariyerApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService _recruiterService;
        private readonly IMapper _mapper;

        public RecruiterController(IRecruiterService recruiterService, IMapper mapper)
        {
            _recruiterService = recruiterService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterRecruiter([FromBody] CreateRecruiterRequest request)
        {
            try
            {
                var recruiter = _mapper.Map<Recruiter>(request);
                await _recruiterService.RegisterRecruiterAsync(recruiter);

                return CreatedAtAction(nameof(RegisterRecruiter), new { id = recruiter.Id }, recruiter);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
