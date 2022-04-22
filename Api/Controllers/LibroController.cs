using Application;
using Application.InputModel;
using Application.ViewModel;
using Domain.Exceptions;
using Domain.Models;
using Domain.Models.Repositories;
using Infraestructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PJENL.Shared.Kernel.Responses;
using PJENL.Shared.Kernel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _service;
        private readonly Contexto _context;
        public LibroController(ILibroService service, Contexto context)
        {
            _service = service;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string searchValue = null, int skip = 0, int take = 10)
        {
            var result = await _service.GetAll(searchValue, skip, take);
            ResponseFactory<CodigosRespuestaLibreria,GridResponse<IEnumerable<LibroViewModel>,LibroViewModel>> responseFactory 
                = new ResponseFactory<CodigosRespuestaLibreria, GridResponse<IEnumerable<LibroViewModel>, LibroViewModel>>(CodigosRespuestaLibreria.Succes_01,result,true,HttpStatusCode.OK);
            Response<GridResponse<IEnumerable<LibroViewModel>,LibroViewModel>> response = new Response<GridResponse<IEnumerable<LibroViewModel>,LibroViewModel>>(responseFactory);
            response.ResponseDate = DateTime.Now;
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(LibroInputModel libro)
        {
            var data = await _service.Registrar(libro);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _service.GetById(id);
            return Ok(data);
        }
        [ProducesResponseType(typeof(Response),200)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var data = await _service.Eliminar(id);
            ResponseFactory<CodigosRespuestaLibreria> responseFactory = 
                new ResponseFactory<CodigosRespuestaLibreria>(CodigosRespuestaLibreria.Succes_02,data,HttpStatusCode.OK,id.ToString());
            Response response = new Response(responseFactory);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch]
        public async Task<IActionResult> Actualizar(LibroEditInputModel libro)
        {
            var data = await _service.Actualizar(libro);
            return Ok(data);
        }
        [HttpPost("relacionar/{idLibro}/{idLibreria}")]
        public async Task<IActionResult> RelacionarLibreria(Guid idLibro, int idLibreria)
        {
            //var data = await _service.RelacionarLibroLibreria(idLibro, idLibreria);
            return Ok();
        }

    }

}