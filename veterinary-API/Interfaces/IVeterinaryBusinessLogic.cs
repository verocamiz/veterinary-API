using veterinary_API.DTOs;

namespace veterinary_API.Interfaces
{
    public interface IVeterinaryBusinessLogic
    {
        /// <summary>
        /// Retrieves all veterinarians from the system.
        /// </summary>
        /// <remarks>
        /// This method returns a collection of <see cref="VeterinaryDTO"/> objects representing
        /// all veterinarians stored in the database.
        /// </remarks>
        /// <returns>
        /// An asynchronous task that produces an enumerable collection of <see cref="VeterinaryDTO"/> instances.
        /// </returns>
        public Task<IEnumerable<VeterinaryDTO>> ObtenerTodosAsync();

        /// <summary>
        /// Retrieves a specific veterinarian by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the veterinarian to retrieve.</param>
        /// <returns>
        /// An asynchronous task that produces a collection of <see cref="VeterinaryDTO"/> objects
        /// matching the given identifier. Returns an empty collection if no records are found.
        /// </returns>
        public Task<VeterinaryDTO> ObtenerByIdAsync(int id);
        public Task<VeterinaryDTO> CreateVetAsync(VeterinaryCreateUpdateDTO vet);
        public Task<VeterinaryDTO> UpdateVetAsync(VeterinaryCreateUpdateDTO dto);
    }
}
