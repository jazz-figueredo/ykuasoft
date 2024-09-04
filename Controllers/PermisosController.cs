using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ykuasoft.Data;
using ykuasoft.Models;

namespace ykuasoft.Controllers
{
    [ApiController]
    [Route("permisos")]
    public class PermisosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PermisosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Permisos>>> GetPermisos()
        {
            var permisos = await _context.Permisos.ToListAsync();
            return Ok(permisos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Permisos>> GetPermiso(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);

            if (permiso == null)
            {
                return NotFound();
            }

            return Ok(permiso);
        }


        [HttpPost("crear")]
        public async Task<ActionResult<Permisos>> PostPermiso(Permisos permiso)
        {
            _context.Permisos.Add(permiso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPermiso), new { id = permiso.Id_permiso }, permiso);
        }


        [HttpPut("{id}/actualizar")]
        public async Task<IActionResult> PutPermiso(int id, Permisos permiso)
        {
            if (id != permiso.Id_permiso)
            {
                return BadRequest();
            }

            _context.Entry(permiso).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}/eliminar")]
        public async Task<IActionResult> DeletePermiso(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }

            _context.Permisos.Remove(permiso);
            await _context.SaveChangesAsync();

            return Ok("Se eliminó el permiso correctamente");
        }
    }
}
