﻿using AutoMapper;
using MedicalAppAPI.DTOs;
using MedicalAppAPI.Models.Domains;
using MedicalAppAPI.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiNET.Utils;

namespace MedicalAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordActions _medicalRecordActions;
        private readonly IMapper _mapper;

        public MedicalRecordController(IMedicalRecordActions medicalRecordActions, IMapper mapper)
        {
            _medicalRecordActions = medicalRecordActions;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateMedicalRecord([FromBody] MedicalRecordDto medicalRecordDto)
        {
            var newRecord = _mapper.Map<MedicalRecord>(medicalRecordDto);
            newRecord = await _medicalRecordActions.AddMedicalRecordAsync(newRecord);
            return CreatedAtAction(nameof(CreateMedicalRecord), newRecord);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetMedicalRecordsByIdAsync([FromRoute] Guid id)
        {
            var record = await _medicalRecordActions.GetMedicalRecordByIdAsync(id);
            if (record == null)
            {
                return NotFound($"No record found with ID {id}");
            }
            return Ok(_mapper.Map<MedicalRecord>(record));
        }
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllMedicalRecords([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var records = await _medicalRecordActions.GetAllMedicalRecordAsync(filterOn, filterQuery,
                pageNumber, pageSize);
            return Ok(_mapper.Map<List<MedicalRecord>>(records));
        }
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateMedicalRecordAsync([FromRoute] Guid id, [FromBody] UpdateRecordDto updateRecordDto)
        {
            var recordToUpdate = await _medicalRecordActions.GetMedicalRecordByIdAsync(id);
            if (recordToUpdate != null)
            {
                _mapper.Map(updateRecordDto, recordToUpdate);

                var updatedRecord = await _medicalRecordActions.UpdateMedicalRecordAsync(id, recordToUpdate);
                return Ok(updatedRecord);
            }
            else
            {
                return NotFound($"No record found with ID {id}");
            }
            
        }
    }
}
