using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJENL.Shared.Kernel.Responses;
using PJENLShared.Kernel.Auth;
using PJENLShared.Kernel.Auth.InputModel;
using PJENLShared.Kernel.Auth.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// Registrar libro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Response<AuthViewModel>), 200)]
        public async Task<IActionResult> Post(IniciarSesionInputModel request)
        {
            AuthViewModel response = await _authService.IniciarSesion(request);
            ResponseFactory<CodigosRespuestaLibreria, AuthViewModel> responseFactory
                = new ResponseFactory<CodigosRespuestaLibreria, AuthViewModel>(CodigosRespuestaLibreria.Succes_01, response, true, HttpStatusCode.OK);
            responseFactory.ResponseDate = DateTime.Now;
            Response<AuthViewModel> dataResponse = new Response<AuthViewModel>(responseFactory);
            var cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Path = "/",
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None
            };
            Response.Cookies.Append("Account", response.refresh_token, cookieOptions);
            return Ok(dataResponse);
        }
    }
}
