namespace ykuasoft.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ykuasoft.Data;
    using ykuasoft.Models;

    [ApiController]
    [Route("roles")]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        
        [HttpPost("crear")]
        public async Task<ActionResult<Roles>> PostRol(Roles rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRol), new { id = rol.Id_rol }, rol);
        }

        
        [HttpPut("{id}/actualizar")]
        public async Task<IActionResult> PutRol(int id, Roles rol)
        {
            if (id != rol.Id_rol)
            {
                return BadRequest();
            }

            _context.Entry(rol).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}/eliminar")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();

            return Ok("Se eliminó el rol correctamente");
        }
    }
}
