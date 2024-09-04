namespace ykuasoft.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ykuasoft.Data;  
    using ykuasoft.Models;
    using ykuasoft.Request;

    [ApiController]
    [Route("usuario")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            var Usuarios = await _context.Usuarios.ToListAsync();
            return Ok(Usuarios);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new { message = "El usuario no existe." });
            }

            return Ok(usuario);
        }

        // POST: api/Usuarios
        [HttpPost("crear")]
        public async Task<ActionResult<Usuarios>> PostUsuario(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var response = new
            {
                message = "Usuario creado correctamente.",
                usuario
            };

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id_usuario }, response);
        }

        // PUT: api/Usuarios/5/actualizar
        [HttpPut("{id}/actualizar")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] Usuarios usuario)
        {
            if (id != usuario.Id_usuario)
            {
                return BadRequest(new { message = "El ID proporcionado no coincide con el ID del usuario." });
            }

            // Obtener el usuario existente
            var existingUsuario = await _context.Usuarios.FindAsync(id);
            if (existingUsuario == null)
            {
                return NotFound(new { message = "El usuario no existe." });
            }

            // Actualizar solo los campos proporcionados
            if (string.IsNullOrWhiteSpace(usuario.Nombre_usuario))
            {
                existingUsuario.Nombre_usuario = existingUsuario.Nombre_usuario;
            }
            else
            {
                existingUsuario.Nombre_usuario = usuario.Nombre_usuario;
            }

            if (string.IsNullOrWhiteSpace(usuario.Contrasenha))
            {
                existingUsuario.Contrasenha = existingUsuario.Contrasenha;
            }
            else
            {
                existingUsuario.Contrasenha = usuario.Contrasenha;
            }

            if (string.IsNullOrWhiteSpace(usuario.Activo))
            {
                existingUsuario.Activo = existingUsuario.Activo;
            }
            else
            {
                existingUsuario.Activo = usuario.Activo;
            }

            // Verifica si el valor de Fecha_alta en la solicitud es diferente de null
            if (!usuario.Fecha_alta.HasValue)
            {
                existingUsuario.Fecha_alta = existingUsuario.Fecha_alta;
            }
            else
            {
                existingUsuario.Fecha_alta = usuario.Fecha_alta;
            }

            // Verifica si el valor de FechaInactivacion en la solicitud es diferente de null
            if (!usuario.FechaInactivacion.HasValue)
            {
                existingUsuario.FechaInactivacion = existingUsuario.FechaInactivacion;
            }
            else
            {
                existingUsuario.FechaInactivacion = usuario.FechaInactivacion;
            }
            // Repite para otros campos según sea necesario

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario actualizado correctamente" });
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Hubo un conflicto al actualizar el usuario. Intente nuevamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Ocurrió un error al actualizar el usuario.",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
        }



        [HttpPut("{id}/inactivar")]
        public async Task<IActionResult> InactivarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new { message = "El usuario no existe." });
            }

            usuario.Activo = "N";
            usuario.FechaInactivacion = DateTime.UtcNow;  // Asume que existe una propiedad FechaInactivacion

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "El usuario fue inactivado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al inactivar el usuario.", details = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Busca al usuario por el nombre de usuario
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nombre_usuario == request.Usuario);

            // Si el usuario no existe o la contraseña es incorrecta
            if (usuario == null || usuario.Contrasenha != request.Contrasenha || usuario.Nombre_usuario != request.Usuario)
            {
                return Unauthorized("Credenciales inválidas");
            }

            // Si las credenciales son correctas
            return Ok("Inicio de sesión exitoso");
        }


    }
}
