using Microsoft.AspNetCore.Mvc;
using SixDegrees.PruebaSD.Negocio;
using SixDegrees.PruebaSD.Entidades;
using System.Collections.Generic;

namespace SixDegrees.PruebaSD.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _service.GetAllUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(decimal id)
        {
            var usuario = _service.GetUsuarioById(id);
            return usuario is null ? NotFound() : Ok(usuario);
        }
    }
}