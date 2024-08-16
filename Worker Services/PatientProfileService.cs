using QRCoder;
using System.Drawing;

public class PatientProfileService
{
    private readonly IConfiguration _configuration;

    public PatientProfileService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GeneratePatientProfileUrl(Guid patientId)
    {
        var baseUrl = _configuration["BaseUrl"];
        return $"{baseUrl}/PatientProfile/Profile/{patientId}";
    }

    public string GenerateQRCodeAsBase64(string url)
    {
        using QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
        byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);
        return Convert.ToBase64String(qrCodeAsBitmapByteArr);
    }
}