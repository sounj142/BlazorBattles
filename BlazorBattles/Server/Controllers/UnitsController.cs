using AutoMapper;
using BlazorBattles.Server.Data.Interfaces;
using BlazorBattles.Server.Entities;
using BlazorBattles.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UnitDto>>> GetUnits()
        {
            var units = await _unitOfWork.UnitRepository.GetUnits();
            return Ok(_mapper.Map<List<UnitDto>>(units));
        }

        [HttpPost]
        public async Task<ActionResult<UnitDto>> AddUnit(UnitDto dto)
        {
            var unit = _mapper.Map<Unit>(dto);
            
            _unitOfWork.UnitRepository.Add(unit);
            
            await _unitOfWork.Complete();
            return CreatedAtAction("GetUnits", _mapper.Map<UnitDto>(unit));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUnit(UnitDto dto)
        {
            var unit = await _unitOfWork.UnitRepository.GetUnit(dto.Id);

            if (unit == null) return NotFound("Unit not found");

            _mapper.Map(dto, unit);
            await _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUnit(int id)
        {
            var unit = await _unitOfWork.UnitRepository.GetUnit(id);

            if (unit == null) return NotFound("Unit not found");

            _unitOfWork.UnitRepository.Delete(unit);
            await _unitOfWork.Complete();
            return NoContent();
        }
    }
}
