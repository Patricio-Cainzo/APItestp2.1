using APItestp2._1.Models;
using APItestp2._1.Models.Dtos;
using APItestp2._1.Models.Repositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APItestp2._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepositorio _repository;
        private readonly IMapper _mapper;

        // Constructor que recibe las dependencias necesarias mediante inyección de dependencias
        public PersonaController(IPersonaRepositorio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonaDto>> ObtenerTodos()
        {
            // Asi obtengo los datos del repositorio
            var personas = _repository.ObtenerTodos();

            // Con esto mapeamos la lista de personas hacia una lista de personas DTO
            var personaDto = _mapper.Map<IEnumerable<PersonaDto>>(personas);

            // Me devuelve los datos en formato json
            return Ok(personaDto);
        }

        // HTTP GET para obtener una persona por su ID
        [HttpGet("{id}")]
        public ActionResult<PersonaDto> ObtenerPorID(int id)
        {
            // obtengo la persona con el ID proporcionado desde el repositorio
            var persona = _repository.ObtenerPorID(id);

            // Verificar si la persona no fue encontrado
            if (persona == null)
            {
                // Devolver una respuesta 404 (Not Found) si el gasto no existe
                return NotFound();
            }

            // Mapear el gasto a un PersonaDto y devolverlo en formato JSON
            var personaDto = _mapper.Map<PersonaDto>(persona);
            return Ok(personaDto);
        }

        // Endpoint HTTP POST para agregar una nueva Persona
        [HttpPost]
        public ActionResult<PersonaRegistroDto> Registrar(PersonaDto personaDto)
        {
            // Mapear el GastoDto recibido a un objeto Gasto
            var persona = _mapper.Map<Persona>(personaDto);

            // Agregar el nuevo gasto al repositorio
            _repository.Registrar(persona);

            // Crear un objeto de respuesta con el ID del gasto agregado y un mensaje
            var responseDto = new PersonaRegistroDto
            {
                Id = persona.Id,
                Mensaje = "Persona agregada exitosamente."
            };

            // Devolver la respuesta en formato JSON
            return Ok(responseDto);
        }

        // Endpoint HTTP PUT para actualizar un gasto existente por su ID
        [HttpPut("{id}")]
        public ActionResult<PersonaActualizarDto> Actualizar(int id, PersonaDto personaDto)
        {
            // Obtener el gasto existente con el ID proporcionado desde el repositorio
            var exitingPersona = _repository.ObtenerPorID(id);

            // Verificar si el gasto no fue encontrado
            if (exitingPersona == null)
            {
                // Devolver una respuesta 404 (Not Found) si el gasto no existe
                return NotFound();
            }

            // Aplicar las actualizaciones desde el PersonaDto al Persona existente
            _mapper.Map(personaDto, exitingPersona);

            // Actualizar el gasto en el repositorio
            _repository.Actualizar(exitingPersona);

            // Crear un objeto de respuesta con un mensaje
            var responseDto = new PersonaActualizarDto
            {
                Mensaje = "Datos actualizados exitosamente."
            };

            return Ok(responseDto);
        }

        // Endpoint HTTP DELETE para eliminar un gasto por su ID
        [HttpDelete("{id}")]
        public ActionResult<PersonaEliminarDto> Eliminar(int id)
        {
            // Obtener el gasto existente con el ID proporcionado desde el repositorio
            var exitingPersona = _repository.ObtenerPorID(id);

            // Verificar si el gasto no fue encontrado
            if (exitingPersona == null)
            {
                // Devolver una respuesta 404 (Not Found) si el gasto no existe
                return NotFound();
            }

            // Eliminar el gasto del repositorio
            _repository.Eliminar(id);

            // Crear un objeto de respuesta con un mensaje
            var responseDto = new PersonaEliminarDto
            {
                Mensaje = "Datos eliminados exitosamente."
            };


            return Ok(responseDto);
        }
    }
}

