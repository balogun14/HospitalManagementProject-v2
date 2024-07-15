namespace HospitalManagementProject.Models;

public class Email(string reciever, string body)
{
    public string Reciever { get; init; } = reciever;
    public string Body { get; init; } = body;
}