using APItestp2._1.Context;
using Microsoft.EntityFrameworkCore;
namespace APItestp2._1.Models.Repositorio
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly PersonaDbContext _context;

        public PersonaRepositorio(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> ObtenerTodos()
        {
            return _context.Persona.ToList();
        }

        public Persona ObtenerPorID(int id)
        {
            return _context.Persona.Find(id);
        }

        public void Registrar(Persona persona)
        {
            _context.Persona.Add(persona);
            _context.SaveChanges();
        }

        public void Actualizar(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Eliminar(int id)
        {
            var persona = _context.Persona.Find(id);
            _context.Persona.Remove(persona);
            _context.SaveChanges();
        }
    }
}
