
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
                   // ClinicName = v.Clinic?.Name
                });

                return vetsDto;
            }
            catch (RepositoryException ex)
            {
                throw new BusinessException("Error al acceder a los datos del veterinario.", ex);
            }
        }

        public async Task<VeterinaryDTO> ObtenerByIdAsync(int id)
        {
            try
            {
                var v = await _repo.GetVeterinaryByIdAsync(id);

                if (v == null)
                    throw new BusinessException($"Veterinary with ID {id} was not found.");

                var vetsDto = new VeterinaryDTO
                {
                    Id = v.Id,
                    FullName = $"{v.Name} {v.Lastname}", 
                };

                return vetsDto;
            }
            catch (RepositoryException ex)
            {
                throw new BusinessException("Error al acceder a los datos del veterinario.", ex);
            }
        }

        public async Task<VeterinaryDTO> CreateVetAsync(VeterinaryCreateUpdateDTO dto)
        {
            try
            {
                var newVet = new Veterinary
                {
                    Name = dto.Name,
                    Lastname = dto.Lastname,
                    Address = dto.Address,
                    BirthDate = dto.BirthDate,
                    YearStartedWorking = dto.YearStartedWorking
                };

                var patients = await _repo.GetPatientsByIds(dto.Patients);

                newVet.Patients = patients;

                var createdVet = await _repo.CreateVeterinaryAsync(newVet);
                 
                return new VeterinaryDTO
                {
                    Id = createdVet.Id,
                    FullName = $"{createdVet.Name} {createdVet.Lastname}", 
                };
            }
            catch (RepositoryException ex)
            {
                throw new BusinessException("Error al acceder a los datos del veterinario.", ex.InnerException);
            }
        }

        public async Task<VeterinaryDTO> UpdateVetAsync(VeterinaryCreateUpdateDTO dto)
        {
            try
            {
                var vet = await _repo.GetVeterinaryByIdAsync(dto.Id);
                if (vet == null)
                    throw new BusinessException($"Veterinary with ID {dto.Id} not found.");
                 
                vet.Name = dto.Name;
                vet.Lastname = dto.Lastname;
                vet.Address = dto.Address;
                vet.BirthDate = dto.BirthDate;
                vet.YearStartedWorking = dto.YearStartedWorking;
                 
                var patientsDB = await _repo.GetPatientsByIds(dto.Patients);
                 
                vet.Patients.Clear();
                foreach (var p in patientsDB)
                    vet.Patients.Add(p);
                 
                var updatedVet = await _repo.UpdateVeterinaryAsync(vet);
                 
                return new VeterinaryDTO
                {
                    Id = updatedVet.Id,
                    FullName = $"{updatedVet.Name} {updatedVet.Lastname}",
                };
                 
            }
            catch (RepositoryException ex)
            {
                throw new BusinessException("Error al acceder a los datos del veterinario.", ex.InnerException);
            }
        }
    }

}
