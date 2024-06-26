namespace BranchesLocatorAPI.Models
{
    public class AddBranchDto
    {
        public required string PostCode { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string Email { get; set; }
        public required string Canton { get; set; }
        public required string Website { get; set; }
        public required string OpeningHours { get; set; }
        public required string Phone { get; set; }
        public required double Lat { get; set; }
        public required double Lng { get; set; }
        public string? Base64Image { get; set; }
    }
}
