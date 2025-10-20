using veterinary_API.Models;

namespace veterinary_API.Interfaces
{
    public interface IVeterinaryRepository
    {
        /// <summary>
        /// Retrieves all veterinarians from the database.
        /// </summary>
        /// <remarks>
        /// This method returns a complete list of <see cref="Veterinary"/> entities,
        /// including related data (e.g., associated patients) if configured.
        /// </remarks>
        /// <returns>
        /// An asynchronous task that produces an enumerable collection of <see cref="Veterinary"/> objects.
        /// </returns>
        Task<IEnumerable<Veterinary>> GetAllAsync();
        Task<Veterinary?> GetVeterinaryByIdAsync(int id);

        public Task<ICollection<Patient>> GetPatientsByIds(IEnumerable<int> patientIds);

        public Task<Veterinary> CreateVeterinaryAsync(Veterinary entity);

        public  Task<Veterinary> UpdateVeterinaryAsync(Veterinary entity);
        public Task DeleteVetAsync(Veterinary entity);
    }
}
