using veterinary_API.DTOs;

namespace veterinary_API.Models
{
    public class Veterinary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int YearStartedWorking { get; set; }
        public int ClinicId { get; set; } // FK
        public Clinic Clinic { get; set; } // Table

        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
         
        public Veterinary() { }
         
        public Veterinary(VeterinaryDTO dto)
        {
           // UpdateFromDto(dto);
        }


        public VeterinaryDTO ToDto()
        {
            return new VeterinaryDTO
            {
                Id = Id,
                FullName = $"{Name} {Lastname}",
                ClinicName = Clinic?.Name,
                ClinicAddress = Clinic?.Address,
                YearStartedWorking = YearStartedWorking
            };
        }

        // Actualizar entidad a partir de DTO (creación o edición)
        //public void UpdateFromDto(VeterinaryDTO dto)
        //{
        //    // Separar nombre y apellido
        //    var names = dto.FullName.Split(' ');
        //    Name = names[0];
        //    Lastname = names.Length > 1 ? string.Join(' ', names.Skip(1)) : "";

        //    YearStartedWorking = dto.YearStartedWorking;
        //    ClinicId = dto.ClinicId;
        //}
    }
}
