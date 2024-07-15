using HospitalManagementProject.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Quartz;

namespace HospitalManagementProject.WorkerServices
{
    public class EmailJob(IConfiguration configuration) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var email = (Email)context.MergedJobDataMap["email"];

            var smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpSettings>();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Hospital Management", smtpSettings?.Username));
            message.To.Add(new MailboxAddress("Patient",email.Reciever));
            message.Subject = "Appointment Reminder";
            message.Body = new TextPart("This is Your Appointment reminder")
            {
                Text = email.Body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpSettings.Host, smtpSettings.Port, false);
                await client.AuthenticateAsync(smtpSettings.Username, smtpSettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }

    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}