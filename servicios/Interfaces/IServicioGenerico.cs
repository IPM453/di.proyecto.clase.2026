using di.proyecto.clase._2026.Datos.Repositorios;


namespace di.proyecto.clase._2026.Servicios.Interfaces
{
    public interface IServicioGenerico<T> : IGenericRepository<T>
        where T : class
    {
    }
}
