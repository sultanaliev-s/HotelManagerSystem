﻿using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.BL.Exceptions;
using HotelManagerSystem.Models.DTOs;
using HotelManagerSystem.Models.Entities;
using HotelManagerSystem.Models.Request.CreateRequest;
using HotelManagerSystem.Models.Request.UpdateRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CouchettesController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly CouchetteServices _service;

        public CouchettesController(CouchetteServices service, ILogger<CitiesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] CreateCouchetteRequest request)
        {
            try
            {
                var country = await _service.Create(request);
                return Created("", country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Couchette}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(UpdateNameDirectoryRequest request)
        {
            try
            {
                await _service.Update(request);
            }
            catch (EntityNotFoundException<Couchette> ex)
            {
                return NotFound(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing request from {Couchette}", request);
                return BadRequest(new ErrorResponse(ex.Message));
            }

            return Ok();
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            Couchette couchette = await _service.GetByIdAsync(id);
            if (couchette == null)
                return NotFound(new ErrorResponse("Couchette not found"));
            await _service.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<ActionResult<CouchetteDto>> GetById(int id)
        {
            Couchette couchette = await _service.GetByIdAsync(id);
            if (couchette == null)
                return NotFound(new ErrorResponse("Couchette not found"));

            return Ok(new CouchetteDto(couchette));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<ActionResult<List<CouchetteDto>>> GetAll()
        {
            var list = await _service.GetAll();

            return Ok(list.Select(dep => new CouchetteDto(dep)).ToList());
        }
    }
}
