using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ykuasoft.Data;
using ykuasoft.Models;

namespace ykuasoft.Controllers
{
    [ApiController]
    [Route("timbrado")]
    public class TimbradoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TimbradoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Timbrado>>> GetTimbrados()
        {
            var timbrados = await _context.Timbrado.ToListAsync();
            return Ok(timbrados);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Timbrado>> GetTimbrado(int id)
        {
            var timbrado = await _context.Timbrado.FindAsync(id);

            if (timbrado == null)
            {
                return NotFound();
            }

            return Ok(timbrado);
        }


        [HttpPost("crear")]
        public async Task<ActionResult<Timbrado>> Posttimbrado(Timbrado timbrado)
        {
            _context.Timbrado.Add(timbrado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTimbrado), new { id = timbrado.Nro_timbrado }, timbrado);
        }


        [HttpPut("{id}/actualizar")]
        public async Task<IActionResult> PutTimbrado(int id, Timbrado timbrado)
        {
            if (id != timbrado.Nro_timbrado)
            {
                return BadRequest();
            }

            _context.Entry(timbrado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}/eliminar")]
        public async Task<IActionResult> DeleteTimbrado(int id)
        {
            var timbrado = await _context.Timbrado.FindAsync(id);
            if (timbrado == null)
            {
                return NotFound();
            }

            _context.Timbrado.Remove(timbrado);
            await _context.SaveChangesAsync();

            return Ok("Se eliminó el timbrado correctamente");
        }
    }
}
