using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCRUD.API.Domain.DTO.Regions;
using WebApiCRUD.API.Domain.Entity;
using WebApiCRUD.API.Repositories.Interfaces;

namespace WebApiCRUD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();

            return Ok(_mapper.Map<List<RegionDTO>>(regions));
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
                return NotFound();

            return Ok(_mapper.Map<RegionDTO>(region));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO request)
        {
            if (ModelState.IsValid)
            {
                var region = await _regionRepository.CreateAsync(_mapper.Map<Region>(request));

                return CreatedAtAction(nameof(GetById), new { id = region.Id }, _mapper.Map<RegionDTO>(region));
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO request)
        {
            if (ModelState.IsValid)
            {
                var region = await _regionRepository.UpdateAsync(id, request);
                if(region == null)
                    return NotFound();

                return Ok(_mapper.Map<RegionDTO>(request));
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);

            if(region == null)
               return NotFound();

            return Ok(_mapper.Map<RegionDTO>(region));
        }
    }
}
