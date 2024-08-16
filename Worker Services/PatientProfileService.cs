using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

public class PatientProfileService
{
    private readonly IConfiguration _configuration;

    public PatientProfileService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GeneratePatientProfileUrl(int patientId)
    {
        var baseUrl = _configuration["BaseUrl"];
        return $"{baseUrl}/PatientDetails/{patientId}";
    }

    public string GenerateQRCodeAsBase64(string url)
    {
        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q))
        using (QRCode qrCode = new QRCode(qrCodeData))
        {
            using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                return Convert.ToBase64String(byteImage);
            }
        }
    }
}