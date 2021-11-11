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
        private readonly ILibroRepository _repository;
        public LibroController(ILibroRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string searchValue = null, int skip = 0, int take = 10)
        {
            var result = await _repository.GetLibros(searchValue, skip, take);
            return Ok(result);
        }
        [HttpGet("Registrar")]
        public async Task<IActionResult> Registrar()
        {
            await _repository.Registrar();
            return Ok();
        }
    }
}
