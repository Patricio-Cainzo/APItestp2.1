namespace APItestp2._1.Models.Repositorio
{
    public interface IPersonaRepositorio
    {
        IEnumerable<Persona> ObtenerTodos();
        Persona ObtenerPorID(int id);
        void Registrar(Persona persona);
        void Actualizar(Persona persona);
        void Eliminar(int id);
    }
}
