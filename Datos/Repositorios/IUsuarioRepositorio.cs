using di.proyecto.clase._2026.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2026.Datos.Repositorios
{
    public interface IUsuarioRepositorio : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetUsuarioByUserNameAsync(string username, CancellationToken cancellationToken = default);
    }
}
