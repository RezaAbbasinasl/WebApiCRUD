﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCRUD.API.CustomActionFilter;
using WebApiCRUD.API.Domain.DTO.Difficulties;
using WebApiCRUD.API.Domain.Entity;
using WebApiCRUD.API.Repositories.Interfaces;

namespace WebApiCRUD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficultyRepository _difficultyRepository;
        private readonly IMapper _mapper;

        public DifficultyController(IDifficultyRepository difficultyRepository, IMapper mapper)
        {
            _difficultyRepository = difficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<DifficultyDTO>>(await _difficultyRepository.GetAllAsync()));
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var difficulty = await _difficultyRepository.GetByIdAsync(id);

            if (difficulty == null)
                return NotFound();

            return Ok(_mapper.Map<DifficultyDTO>(difficulty));
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddDifficultyDTO request)
        {

            var difficulty = await _difficultyRepository.CreateAsync(_mapper.Map<Difficulty>(request));

            return CreatedAtAction(nameof(GetById), new { id = difficulty.Id }, _mapper.Map<DifficultyDTO>(difficulty));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var difficulty = await _difficultyRepository.DeleteAsync(id);
            if (difficulty == null)
                return NotFound();

            return Ok(_mapper.Map<DifficultyDTO>(difficulty));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDifficultyDTO request)
        {

            var difficulty = await _difficultyRepository.UpdateAsync(id, request);

            if (difficulty == null)
                return NotFound();

            return Ok(_mapper.Map<DifficultyDTO>(difficulty));
        }
    }
}
