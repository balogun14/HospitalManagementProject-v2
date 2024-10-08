using System.Net;
using System.Net.Mail;

namespace HospitalManagementProject.Worker_Services;

public class SendEmailService()
{
    public static void SendMail(string recipientEmail, string messageBody,string subject="Appointment Due Notification" ,string senderEmail = "awwalbalogun06@gmail.com")
    {
        var message = new MailMessage(senderEmail, recipientEmail);
        var smtp = new SmtpClient();
        message.Subject = subject;
        message.Body = messageBody;
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com"; //for gmail host
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(senderEmail, "aqogbrzdrgffhkhf");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        try
        {
            smtp.Send(message);
            Console.WriteLine("Sent Email Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);

        }
    }
    
    public static async Task SendMailAsync(string recipientEmail, string messageBody, string subject = "Appointment Due Notification", string senderEmail = "awwalbalogun06@gmail.com")
    {
        var message = new MailMessage(senderEmail, recipientEmail);
        message.Subject = subject;
        message.Body = messageBody;
        message.IsBodyHtml = true;  

        using var smtp = new SmtpClient();
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com"; //for gmail host
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(senderEmail, "aqogbrzdrgffhkhf");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        try
        {
            await smtp.SendMailAsync(message);
            Console.WriteLine("Sent Email Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            throw;  // Re-throw the exception to be handled by the caller
        }
    }
}