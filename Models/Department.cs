namespace ClinicMVC.Models
{
    public class Department:BaseEntity
    {
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
