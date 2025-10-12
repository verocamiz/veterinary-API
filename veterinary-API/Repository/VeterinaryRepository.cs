using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using veterinary_API.Exceptions;
using veterinary_API.Interfaces;
using veterinary_API.Models;

namespace veterinary_API.Repository
{
    public class VeterinaryRepository :IVeterinaryRepository
    {

        private readonly VeterinaryContext _context;

        public VeterinaryRepository(VeterinaryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veterinary>> GetAllAsync()
        { 
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                return  await _context.Veterinaries
                                .Include(v => v.Patients)
                                .ToListAsync();
            }
         
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new RepositoryException($"Error when trying to get the veterinaries", ex);
            }
        }
    }
}
