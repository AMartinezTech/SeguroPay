using QRCoder;
using System.Data;

namespace AMartinezTech.WinForms.Utils;

public class QrGenerator
{
    public static DataTable GenerateQr(Guid docId)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrData = qrGenerator.CreateQrCode(docId.ToString(), QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new QRCode(qrData);
        using Bitmap qrBitmap = qrCode.GetGraphic(20);

        using var ms = new MemoryStream();
        qrBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

        // Creamos el DataTable que usará el RDLC
        DataTable qrTable = new("QrTable");
        qrTable.Columns.Add("QrImage", typeof(byte[]));

        // Insertamos la imagen QR como byte[]
        qrTable.Rows.Add(ms.ToArray());

        return qrTable;
    }
}
