namespace ykuasoft.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ykuasoft.Data;
    using ykuasoft.Models;

    [ApiController]
    [Route("forma-pago")]
    public class FormaPagoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FormaPagoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<FormaPago>>> GetFormaPago()
        {
            var formaPago = await _context.FormaPago.ToListAsync();
            return Ok(formaPago);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPago>> GetFormaPago(int id)
        {
            var formaPago = await _context.FormaPago.FindAsync(id);

            if (formaPago == null)
            {
                return NotFound();
            }

            return Ok(formaPago);
        }


        [HttpPost("crear")]
        public async Task<ActionResult<Bancos>> PostFormaPago(FormaPago formaPago)
        {
            _context.FormaPago.Add(formaPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFormaPago), new { id = formaPago.Id_forma_pago }, formaPago);
        }


        [HttpPut("{id}/actualizar")]
        public async Task<IActionResult> PutFormaPago(int id, FormaPago formaPago)
        {
            if (id != formaPago.Id_forma_pago)
            {
                return BadRequest();
            }

            _context.Entry(formaPago).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}/eliminar")]
        public async Task<IActionResult> DeleteFormaPago(int id)
        {
            var formaPago = await _context.FormaPago.FindAsync(id);
            if (formaPago == null)
            {
                return NotFound();
            }

            _context.FormaPago.Remove(formaPago);
            await _context.SaveChangesAsync();

            return Ok("Se eliminó la forma de pago correctamente");
        }
    }
}
