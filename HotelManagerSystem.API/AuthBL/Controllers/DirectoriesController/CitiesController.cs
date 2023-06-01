﻿using HotelManagerSystem.BL.Directories;
using HotelManagerSystem.DAL.Data;
using HotelManagerSystem.DAL.Responses;
using HotelManagerSystem.Models.Data;
using HotelManagerSystem.Models.Request.UpdateRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers.DirectoriesController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        private readonly IRepository<City, int> _repository;
        private readonly CityServices _service;

        public CitiesController(IRepository<City, int> cityRepository, CityServices service)
        {
            _repository = cityRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<Response> Create([FromBody] string CityName, int countryId)
        {
            City city = new City()
            {
                Name = CityName,
                CountryId = countryId,
                CreatedUtc = DateTime.Now,
                UpdatedUtc = DateTime.Now
            };

            city = await _repository.AddAsync(city);

            return new Response(200, true, null);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateIdNameDirectoryRequest request)
        {
            return await _service.Update(request);
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<Response> Delete(int id)
        {
            _repository.DeleteByIdAsync(id);

            return new Response(200, true, null);
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<Response> GetById(int id)
        {
            City city = await _service.GetByIdAsync(id);

            return new Response(200, true, null);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public async Task<Response> GetAll(int id)
        {
            await _repository.GetAllAsync();
            return new Response(200, true, null);
        }
    }
}