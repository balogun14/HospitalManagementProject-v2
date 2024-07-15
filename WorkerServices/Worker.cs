using HospitalManagementProject.Models;

namespace HospitalManagementProject.WorkerServices;

public class Worker(ILogger<Worker> logger, EmailScheduler emailScheduler) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        await emailScheduler.StartAsync();

        // Example: Schedule email for new appointment
        var newAppointmentEmail = new Email("patient@example.com", "Your appointment has been created.");
        await emailScheduler.ScheduleEmailJob(newAppointmentEmail, DateTimeOffset.Now.AddMinutes(1)); // Immediately for testing

        // Example: Schedule reminder email a day before appointment
        var reminderEmail = new Email("patient@example.com", "Reminder: Your appointment is tomorrow.");
        await emailScheduler.ScheduleEmailJob(reminderEmail, DateTimeOffset.Now.AddDays(1).AddMinutes(-1)); // Adjust time accordingly
    }
}