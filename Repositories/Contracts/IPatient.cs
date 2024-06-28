using HospitalManagementProject.DTO.PatientsDto;

namespace HospitalManagementProject.Repositories.Contracts;

public interface IPatient:IBaseRepo<PatientDto,CreatePatientDto,EditPatientDto>
{
    
}