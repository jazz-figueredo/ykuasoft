namespace ykuasoft.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ykuasoft.Data;
    using ykuasoft.Models;

    [ApiController]
    [Route("caja")]
    public class CajaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CajaController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Caja>>> GetCajas()
        {
            var caja = await _context.Caja.ToListAsync();
            return Ok(caja);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Caja>> GetCaja(int id)
        {
            var caja = await _context.Caja.FindAsync(id);

            if (caja == null)
            {
                return NotFound();
            }

            return Ok(caja);
        }


        [HttpPost("crear")]
        public async Task<ActionResult<Caja>> PostCaja(Caja caja)
        {
            _context.Caja.Add(caja);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCaja), new { id = caja.Nro_caja }, caja);
        }


        [HttpPut("{id}/actualizar")]
        public async Task<IActionResult> PutCaja(int id, Caja caja)
        {
            if (id != caja.Nro_caja)
            {
                return BadRequest();
            }

            _context.Entry(caja).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}/eliminar")]
        public async Task<IActionResult> DeleteCaja(int id)
        {
            var caja = await _context.Caja.FindAsync(id);
            if (caja == null)
            {
                return NotFound();
            }

            _context.Caja.Remove(caja);
            await _context.SaveChangesAsync();

            return Ok("Se eliminó la caja correctamente");
        }
    }

}
