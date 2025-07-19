// SixDegrees.PruebaSD.Negocio/UsuarioService.cs
using SixDegrees.PruebaSD.Entidades;
using SixDegrees.PruebaSD.AccesoDatos;
using System.Collections.Generic;

namespace SixDegrees.PruebaSD.Negocio
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<Usuario> GetAllUsuarios()
        {
            return _repository.GetAll();
        }

        public Usuario? GetUsuarioById(decimal id)
        {
            return _repository.GetById(id);
        }
    }
}