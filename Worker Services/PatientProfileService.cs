using QRCoder;
using System.Drawing;

public class PatientProfileService(IConfiguration configuration, IWebHostEnvironment environment)
{
    public string GeneratePatientProfileUrl(Guid patientId)
    {
        var baseUrl = configuration["BaseUrl"];
        return $"{baseUrl}/PatientProfile/Profile/{patientId}";
    }

    public async Task<string> GenerateAndSaveQRCodeAsync(string url, Guid patientId)
    {
        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        {
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);

            string fileName = $"qrcode_{patientId}.png";
            string filePath = Path.Combine(environment.WebRootPath, "qrcodes", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? string.Empty);

            await File.WriteAllBytesAsync(filePath, qrCodeAsBitmapByteArr);

            return $"{configuration["BaseUrl"]}/qrcodes/{fileName}";
        }
    }
}
