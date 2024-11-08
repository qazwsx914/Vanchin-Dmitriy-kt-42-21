using DmitriyVanchinKt_42_21.Filters.LecturerFilters;
using DmitriyVanchinKt_42_21.Interfaces.LecturersInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DmitriyVanchinKt_42_21.Controllers
{
    [ApiController]
    [Route("controller")]
    public class LecturersController : ControllerBase
    {
        private readonly ILogger<LecturersController> _logger;
        private readonly ILecturerService _lecturerService;

        public LecturersController(ILogger<LecturersController> logger, ILecturerService lecturerService)
        {
            _logger = logger;
            _lecturerService = lecturerService;
        }
        [HttpPost(Name="GetLecturersByCathedra")]
        public async Task<IActionResult> GetLecturersByCathedraAsync(LecturerCathedraFilter filter, CancellationToken cancellationToken = default)
        {
            var lecturers = await _lecturerService.GetLecturersByCathedraAsync(filter, cancellationToken);
            return Ok(lecturers);
        }
    }
}
