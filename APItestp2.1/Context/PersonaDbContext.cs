using APItestp2._1.Models;
using Microsoft.EntityFrameworkCore;
namespace APItestp2._1.Context
{
    public class PersonaDbContext:DbContext
    {
        public PersonaDbContext(DbContextOptions<PersonaDbContext> options) : base(options) { }
        public DbSet<Persona> Persona { get; set; }
    }
}
