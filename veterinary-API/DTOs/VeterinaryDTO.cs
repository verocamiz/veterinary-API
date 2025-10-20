  
namespace veterinary_API.DTOs
{
    public class VeterinaryDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }   
        public int YearStartedWorking { get; set; } 
        public string ClinicName { get; set; }
        public string ClinicAddress { get; set; } 

        public IEnumerable<PatientDTO> Patients { get; set; }  = Enumerable.Empty<PatientDTO>();

    }
}
