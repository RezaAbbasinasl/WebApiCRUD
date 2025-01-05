using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCRUD.API.CustomActionFilter;
using WebApiCRUD.API.Domain.DTO.Regions;
using WebApiCRUD.API.Domain.Entity;
using WebApiCRUD.API.Repositories.Interfaces;

namespace WebApiCRUD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionController> _logger;

        public RegionController(IRegionRepository regionRepository, IMapper mapper, ILogger<RegionController> logger)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();
            _logger.LogInformation("GetAll Regions successfully.");
            return Ok(_mapper.Map<List<RegionDTO>>(regions));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                _logger.LogError($"Region {id} NotFound.");
                return NotFound();
            }
            _logger.LogInformation($"Region {id} Successfully.");
            return Ok(_mapper.Map<RegionDTO>(region));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO request)
        {
            var region = await _regionRepository.CreateAsync(_mapper.Map<Region>(request));
            _logger.LogInformation("Created Region Successfully");
            return CreatedAtAction(nameof(GetById), new { id = region.Id }, _mapper.Map<RegionDTO>(region));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO request)
        {
            var region = await _regionRepository.UpdateAsync(id, request);
            if (region == null)
                return NotFound();

            return Ok(_mapper.Map<RegionDTO>(request));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);

            if (region == null)
                return NotFound();

            return Ok(_mapper.Map<RegionDTO>(region));
        }
    }
}
