using Application.Services;
using Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJENL.Shared.Kernel.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaController : ControllerBase
    {
        private readonly ILibreriaService _libreriaService;
        public LibreriaController(ILibreriaService libreriaService)
        {
            _libreriaService = libreriaService;
        }
        [ProducesResponseType(typeof(IEnumerable<LibreriaViewModel>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAll(string searchValue = null, int skip = 0, int take = 10)
        {
            var data = await _libreriaService.GetAll(searchValue, skip, take);
            return Ok(data);
        }
    }
}
