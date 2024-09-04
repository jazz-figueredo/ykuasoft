namespace ykuasoft.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ykuasoft.Data;
    using ykuasoft.Models;

    [ApiController]
    [Route("bancos")]
    public class BancosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BancosController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Bancos>>> GetBancos()
        {
            var bancos = await _context.Bancos.ToListAsync();
            return Ok(bancos);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Bancos>> GetBanco(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);

            if (banco == null)
            {
                return NotFound();
            }

            return Ok(banco);
        }

       
        [HttpPost("crear")]
        public async Task<ActionResult<Bancos>> PostBanco(Bancos banco)
        {
            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBanco), new { id = banco.Id_banco }, banco);
        }

        
        [HttpPut("{id}/actualizar")]
        public async Task<IActionResult> PutBanco(int id, Bancos banco)
        {
            if (id != banco.Id_banco)
            {
                return BadRequest();
            }

            _context.Entry(banco).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}/eliminar")]
        public async Task<IActionResult> DeleteBanco(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);
            if (banco == null)
            {
                return NotFound();
            }

            _context.Bancos.Remove(banco);
            await _context.SaveChangesAsync();

            return Ok("Se eliminó el banco correctamente");
        }
    }
}
