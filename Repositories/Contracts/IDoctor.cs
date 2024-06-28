using HospitalManagementProject.DTO.DoctorsDto;

namespace HospitalManagementProject.Repositories.Contracts;

public interface IDoctor:IBaseRepo<DoctorDto,CreateDoctorDto,EditDoctorDto>
{
    
}