using Application;
using Application.InputModel;
using Domain.Models;
using Domain.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _service;
        public LibroController(ILibroService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string searchValue = null, int skip = 0, int take = 10)
        {
            var result = await _service.GetAll(searchValue, skip, take);
            return Ok(result);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var data = await _service.Eliminar(id);
            return Ok(data);
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