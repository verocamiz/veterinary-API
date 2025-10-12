namespace veterinary_API.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
