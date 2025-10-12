namespace veterinary_API.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Data { get; set; } 
        public Patient Patient { get; set; }

        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
