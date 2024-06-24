﻿namespace BranchesLocatorAPI.Models
{
    public class AddBranchDto
    {
        public required string Plz { get; set; }
        public required string Firma { get; set; }
        public required string Ort { get; set; }
        public required string Email { get; set; }
        public required string Kanton { get; set; }
        public required string Website { get; set; }
        public required string OpeningHours { get; set; }
        public required string Phone { get; set; }
        public required double Lat { get; set; }
        public required double Lng { get; set; }
        public string? ImageUrl { get; set; }
    }
}
