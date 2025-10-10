using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using veterinary_API.Exceptions;
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

        public async Task<List<Veterinary>> GetAllAsync()
        {
            // para insert update delete
            //   catch (DbUpdateException ex)
            //{
            //    throw new RepositoryException("Error al traer el veterinario en la base de datos.", ex);
           // }
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                return await _context.Veterinaries
                                //.Include(v => v.Consultorio)
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
