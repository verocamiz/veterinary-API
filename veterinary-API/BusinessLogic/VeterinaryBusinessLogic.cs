using NuGet.Protocol.Core.Types;
using veterinary_API.Exceptions;
using veterinary_API.Models;
using veterinary_API.Repository;

namespace veterinary_API.BusinessLogic
{
    public class VeterinaryBusinessLogic
    {
        private readonly IVeterinaryRepository _repo;

        public VeterinaryBusinessLogic(IVeterinaryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Veterinary>> ObtenerTodosAsync()
        { 
            try
            {
                return await _repo.GetAllAsync();
            }
            catch (RepositoryException ex)
            {
                throw new BusinessException("Error al acceder a los datos del veterinario.", ex);
            }
        }
    }
}
