namespace veterinary_API.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BranchCode { get; set; }
        public string Address { get; set; }
        // Relación uno a muchos
        public ICollection<Veterinary> Veterinaries { get; set; } = new List<Veterinary>();
    }
}
