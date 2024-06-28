using HospitalManagementProject.Models;
using HospitalManagementProject.Models.EHR;
using HospitalManagementProject.Models.Inventory;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
}
