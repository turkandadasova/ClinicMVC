namespace ClinicMVC.Models
{
    public class Doctor:BaseEntity
    {
        public string Surname { get; set; } = null!;
        public string Position { get; set; } = null!;
        //public string CoverImage { get; set; } = null!;
      //  public IFormFile CoverFile { get; set; } = null!;
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; } = null!;
    }
}
