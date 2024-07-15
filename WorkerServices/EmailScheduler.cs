using HospitalManagementProject.Models;
using Quartz;
using Quartz.Spi;

namespace HospitalManagementProject.WorkerServices
{
    public class EmailScheduler(ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IScheduler scheduler)
    {
        public async Task StartAsync()
        {
            scheduler = await schedulerFactory.GetScheduler();
            scheduler.JobFactory = jobFactory;
            await scheduler.Start();
        }

        public async Task ScheduleEmailJob(Email email, DateTimeOffset scheduleTime)
        {
            var jobDetail = JobBuilder.Create<EmailJob>()
                .WithIdentity("emailJob", "emailGroup")
                .UsingJobData("email", email.Reciever)
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("emailTrigger", "emailGroup")
                .StartAt(scheduleTime)
                .WithSimpleSchedule(x => x.WithMisfireHandlingInstructionFireNow())
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}