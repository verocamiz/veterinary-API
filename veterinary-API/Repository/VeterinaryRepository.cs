using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            try
            {
                return  await _context.Veterinaries
                                .Include(v => v.Patients)
                                .ToListAsync();
            }
         
            catch (Exception ex)
            { 
                throw new RepositoryException($"Error when trying to get the veterinaries", ex);
            }
        }

        public async Task<Veterinary?> GetVeterinaryByIdAsync(int id)
        {
            try
            {
                return await _context.Veterinaries.
                                Where(vet=>vet.Id == id)
                                .Include(v => v.Patients)
                                .FirstOrDefaultAsync();
            }

            catch (Exception ex)
            {
                throw new RepositoryException($"Error when trying to get the veterinaries", ex);
            }
        }

        public async Task<ICollection<Patient>> GetPatientsByIds(IEnumerable<int> patientIds)
        { 
            try
            {
                if (!patientIds.Any()) return new List<Patient>();
                return await _context.Patients
                                .Where(p => patientIds.Contains(p.Id))
                                .ToListAsync();
            }

            catch (Exception ex)
            { 
                throw new RepositoryException($"Error when trying to get the veterinaries", ex);
            }
        }

        public async Task<Veterinary> CreateVeterinaryAsync(Veterinary entity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
               await _context.Veterinaries.AddAsync(entity);
               await _context.SaveChangesAsync();
               await transaction.CommitAsync(); 
                return entity; 
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new RepositoryException($"Error when trying to get the veterinaries", ex);
            }
        }

        public async Task<Veterinary> UpdateVeterinaryAsync(Veterinary entity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Veterinaries.Update(entity);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return entity;
                 
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new RepositoryException($"Error when trying to get the veterinaries", ex);
            }
        }
         
        public async Task DeleteVetAsync(Veterinary entity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
               

                _context.Veterinaries.Remove(entity);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new RepositoryException($"Error when trying to get the veterinaries", ex);
            }
        }


    }
}
