using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCRUD.API.CustomActionFilter;
using WebApiCRUD.API.Domain.DTO.Walks;
using WebApiCRUD.API.Domain.Entity;
using WebApiCRUD.API.Repositories.Interfaces;

namespace WebApiCRUD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkDTO request)
        {
            var walk = await _walkRepository.CreateAsync(_mapper.Map<Walk>(request));

            return Ok(_mapper.Map<WalkDTO>(walk));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOne, [FromQuery] string? filterQuery, [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            var walks = await _walkRepository.GetAllAsync(filterOne, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            return Ok(_mapper.Map<List<WalkDTO>>(walks));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await _walkRepository.GetByIcAsync(id);
            if (walk == null)
                return NotFound();

            return Ok(_mapper.Map<WalkDTO>(walk));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDTO request)
        {
            var walk = await _walkRepository.UpdateAsync(id, request);

            return Ok(_mapper.Map<WalkDTO>(walk));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walk = await _walkRepository.DeleteAsync(id);

            if (walk == null)
                return NotFound();

            return Ok(_mapper.Map<WalkDTO>(walk));
        }
    }
}
