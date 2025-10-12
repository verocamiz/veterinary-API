using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veterinary_API.BusinessLogic;
using veterinary_API.Exceptions;
using veterinary_API.Interfaces;
using veterinary_API.Models;

namespace veterinary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinariesController : ControllerBase
    {
        private readonly VeterinaryContext _context;

        private readonly IVeterinaryBusinessLogic _VeterinaryBusinessLogic;

        public VeterinariesController(VeterinaryContext context, IVeterinaryBusinessLogic veterinaryBusinessLogic)
        {
            _context = context;
            _VeterinaryBusinessLogic = veterinaryBusinessLogic;
        }

        // mi codigo
        [HttpGet]
        public async Task<IActionResult> GetVeterinariesAsync()
        {
            try
            {
                var vets = await _VeterinaryBusinessLogic.ObtenerTodosAsync();
                return Ok(vets);
            }
            catch (RepositoryException rex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error en el acceso a datos: {rex.Message}");
            }
            catch (BusinessException bex)
            {
                // ⚠️ Error lógico conocido
                return BadRequest($"Error de negocio: {bex.Message}");
            }
            catch (Exception ex)
            {
                // 🚨 Error inesperado
                Console.WriteLine($"[ERROR] {DateTime.Now}: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner: {ex.InnerException.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocurrió un error interno en el servidor. Intente nuevamente más tarde.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeterinaryByIdAsync(int id)
        {
            try
            {
                var vets = await _VeterinaryBusinessLogic.ObtenerByIdAsync(id);
                return Ok(vets);
            }
            catch (RepositoryException rex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error en el acceso a datos: {rex.Message}");
            }
            catch (BusinessException bex)
            {
                // ⚠️ Error lógico conocido
                return BadRequest($"Error de negocio: {bex.Message}");
            }
            catch (Exception ex)
            {
                // 🚨 Error inesperado
                Console.WriteLine($"[ERROR] {DateTime.Now}: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner: {ex.InnerException.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocurrió un error interno en el servidor. Intente nuevamente más tarde.");
            }

        }

        //fin
        // GET: api/Veterinaries
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Veterinary>>> GetVeterinary()
        //{
        //    return await _context.Veterinaries.ToListAsync();
        //}

        // GET: api/Veterinaries/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Veterinary>> GetVeterinary(int id)
        //{
        //    var veterinary = await _context.Veterinaries.FindAsync(id);

        //    if (veterinary == null)
        //    {
        //        return NotFound();
        //    }

        //    return veterinary;
        //}

        // PUT: api/Veterinaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinary(int id, Veterinary veterinary)
        {
            if (id != veterinary.Id)
            {
                return BadRequest();
            }

            _context.Entry(veterinary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinaryExists(id))
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

        //// POST: api/Veterinaries
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Veterinary>> PostVeterinary(Veterinary veterinary)
        //{
        //    _context.Veterinaries.Add(veterinary);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetVeterinary", new { id = veterinary.Id }, veterinary);
        //}

        //// DELETE: api/Veterinaries/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteVeterinary(int id)
        //{
        //    var veterinary = await _context.Veterinaries.FindAsync(id);
        //    if (veterinary == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Veterinaries.Remove(veterinary);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool VeterinaryExists(int id)
        {
            return _context.Veterinaries.Any(e => e.Id == id);
        }
    }
}
