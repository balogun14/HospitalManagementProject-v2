using HospitalManagementProject.Repositories.Services;

namespace HospitalManagementProject.Worker_Services;

public class Worker(ILogger<Worker> logger, IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            using (var scope = serviceProvider.CreateScope())
            {
                var appointmentService = scope.ServiceProvider.GetRequiredService<AppointmentRepo>();
                var result = await appointmentService.GetDueAppointmentsAsync(DateTime.Now);
                foreach (var appointment in result)
                {
                    var daysLeft = (appointment.AppointmentDate.Date - DateTime.Now.Date).Days;
                    if (daysLeft >= 0)
                    {
                        SendEmailService.SendMail(
                            appointment.Patient.Email, 
                            "Appointment Reminder", 
                            $"You have an appointment with Dr. {appointment.Doctor.FirstName} {appointment.Doctor.LastName} in {daysLeft} days."
                        );
                    }
            }
            }
            // Wait until the next day
            var nextRun = DateTime.Today.AddDays(1).AddHours(1); // Run at 1 AM
            var delay = nextRun - DateTime.Now;
            await Task.Delay(delay, stoppingToken);
        }
    }
}