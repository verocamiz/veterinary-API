using veterinary_API.Models;

namespace veterinary_API.Repository
{
    public interface IVeterinaryRepository
    {
        Task<List<Veterinary>> GetAllAsync();
    }
}
