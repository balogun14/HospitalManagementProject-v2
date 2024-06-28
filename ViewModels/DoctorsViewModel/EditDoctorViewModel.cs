
using System.ComponentModel.DataAnnotations;
using HospitalManagementProject.Enums;

namespace HospitalManagementProject.ViewModels.DoctorsViewModel;

public class EditDoctorViewModel
{
    public Guid ID { get; set; }
    [Required(ErrorMessage ="First Name was not supplied")]
    [StringLength(100)]
    public string FirstName { get; set; }
    [Required(ErrorMessage ="Last Name was not supplied")]
    [StringLength(100)]
    public string LastName { get; set; }
    [Required(ErrorMessage ="No Specialization Selected")]
    public Specialization Speciality { get; set; }
}