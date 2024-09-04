namespace ykuasoft.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ykuasoft.Data;  
    using ykuasoft.Models;

    [ApiController]
    [Route("cargos")]
    public class CargosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CargosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cargos
        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Cargos>>> GetCargos()
        {
            var cargos = await _context.Cargos.ToListAsync();
            return Ok(cargos);
        }

        // GET: api/cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargos>> GetCargo(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return Ok(cargo);
        }

        // POST: api/cargos
        [HttpPost("crear")]
        public async Task<ActionResult<Cargos>> PostCargo(Cargos cargo)
        {
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCargo), new { id = cargo.Id_cargo }, cargo);
        }

        // PUT: api/cargos/5
        [HttpPut("{id}/actualizar")]
        public async Task<IActionResult> PutCargo(int id, Cargos cargo)
        {
            if (id != cargo.Id_cargo)
            {
                return BadRequest();
            }

            _context.Entry(cargo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/cargos/5
        [HttpDelete("{id}/eliminar")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();

            return Ok("Se eliminó el cargo correctamente");
        }
    }
}
