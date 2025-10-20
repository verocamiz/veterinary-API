using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veterinary_API.BusinessLogic;
using veterinary_API.DTOs;
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

        [HttpGet(Name = nameof(GetVeterinariesAsync))] 
        public async Task<IActionResult> GetVeterinariesAsync()
        { 
            var vets = await _VeterinaryBusinessLogic.ObtenerTodosAsync();
            return Ok(vets); 
        }

        [HttpGet("{id}", Name = nameof(GetVeterinaryByIdAsync))] 
        public async Task<IActionResult> GetVeterinaryByIdAsync(int id)
        { 
            var vets = await _VeterinaryBusinessLogic.ObtenerByIdAsync(id);
            return Ok(vets); 
        }

        [HttpPost(Name = nameof(CreateVeterinary))] 
        public async Task<IActionResult> CreateVeterinary(VeterinaryCreateUpdateDTO veterinary)
        { 
            var vet = await _VeterinaryBusinessLogic.CreateVetAsync(veterinary);
            return Ok(vet); 
        }
  
        [HttpPut("{id}", Name = nameof(UpdateVeterinaryAsync))] 
        public async Task<IActionResult> UpdateVeterinaryAsync(int id, VeterinaryCreateUpdateDTO veterinary)
        { 
            if (id != veterinary.Id)  return BadRequest();
                
            var vet = await _VeterinaryBusinessLogic.UpdateVetAsync(veterinary);
            return Ok(vet); 
        }

         
        [HttpDelete("{id}", Name = nameof(DeleteVeterinaryAsync))] 
        public async Task<IActionResult> DeleteVeterinaryAsync(int id)
        {
            await _VeterinaryBusinessLogic.DeleteVetAsync(id); 
            return NoContent();
        } 
    }
}
