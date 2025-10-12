
using veterinary_API.DTOs;
using veterinary_API.Exceptions;
using veterinary_API.Interfaces;
using veterinary_API.Models;

namespace veterinary_API.BusinessLogic
{
    public class VeterinaryBusinessLogic : IVeterinaryBusinessLogic
    {
        private readonly IVeterinaryRepository _repo;

        public VeterinaryBusinessLogic(IVeterinaryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<VeterinaryDTO>> ObtenerTodosAsync()
        { 
            try
            {
                var vets = await _repo.GetAllAsync();

                var vetsDto = vets.Select(v => new VeterinaryDTO
                {
                    Id = v.Id,
                    FullName = $"{v.Name} {v.Lastname}",
                    ClinicName = v.Clinic?.Name
                });

                return vetsDto; 
            }
            catch (RepositoryException ex)
            {
                throw new BusinessException("Error al acceder a los datos del veterinario.", ex);
            }
        }

        public async Task<IEnumerable<VeterinaryDTO>> ObtenerByIdAsync(int id)
        {
            try
            {
                var vets = await ObtenerTodosAsync(); 
                return vets.Where(vet => vet.Id == id);
            }
            catch (RepositoryException ex)
            {
                throw new BusinessException("Error al acceder a los datos del veterinario.", ex);
            }
        }
    }

}
