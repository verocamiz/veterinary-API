using veterinary_API.Models;

namespace veterinary_API.DTOs
{
    public class VeterinaryCreateUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int YearStartedWorking { get; set; }
        public IEnumerable<int> Patients { get; set; } = new List<int>();

    }
}
