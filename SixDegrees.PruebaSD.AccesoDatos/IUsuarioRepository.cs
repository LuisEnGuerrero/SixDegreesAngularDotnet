// SixDegrees.PruebaSD.AccesoDatos/IUsuarioRepository.cs
using SixDegrees.PruebaSD.Entidades;
using System.Collections.Generic;


namespace SixDegrees.PruebaSD.AccesoDatos
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario? GetById(decimal id);
    }
}