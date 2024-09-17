using KioscoInformaticoBackend.DataContext;
using KioscoInformaticoServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KioscoInformaticoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesVentasController : ControllerBase
    {
        private readonly KioscoContext _context;

        public DetallesVentasController(KioscoContext context)
        {
            _context = context;
        }

        // GET: api/DetallesVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesVenta>>> GetDetallesVentas()
        {
            return await _context.DetallesVentas.ToListAsync();
        }

        // GET: api/DetallesVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesVenta>> GetDetallesVenta(int id)
        {
            var detallesVenta = await _context.DetallesVentas.FindAsync(id);

            if (detallesVenta == null)
            {
                return NotFound();
            }

            return detallesVenta;
        }

        // PUT: api/DetallesVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesVenta(int id, DetallesVenta detallesVenta)
        {
            if (id != detallesVenta.Id)
            {
                return BadRequest();
            }

            _context.Entry(detallesVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesVentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetallesVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesVenta>> PostDetallesVenta(DetallesVenta detallesVenta)
        {
            _context.DetallesVentas.Add(detallesVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesVenta", new { id = detallesVenta.Id }, detallesVenta);
        }

        // DELETE: api/DetallesVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesVenta(int id)
        {
            var detallesVenta = await _context.DetallesVentas.FindAsync(id);
            if (detallesVenta == null)
            {
                return NotFound();
            }

            _context.DetallesVentas.Remove(detallesVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesVentaExists(int id)
        {
            return _context.DetallesVentas.Any(e => e.Id == id);
        }
    }
}
