namespace veterinary_API.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 

        public int SpecieId { get; set; }
        public Species Specie { get; set; }
        public int? MedicalRecordId { get; set; }
        public MedicalRecord? MedicalRecord { get; set; }
        public ICollection<Veterinary> Veterinaries { get; set; } = new List<Veterinary>();
    }
}
