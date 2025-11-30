using FakeBank.Models;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace FakeBank.Services
{
    public class PdfGenerator : IPdfGenerator
    {
        public byte[] GenerateTransactionConfirmation(Transaction transaction, Confirmation confirmation)
        {
            using var document = new PdfDocument();
            document.Info.Title = "Potwierdzenie przelewu";

            var page = document.AddPage();
            using var gfx = XGraphics.FromPdfPage(page);

            var titleFont = new XFont("Verdana", 18, XFontStyle.Bold);
            var labelFont = new XFont("Verdana", 10, XFontStyle.Regular);
            var valueFont = new XFont("Verdana", 10, XFontStyle.Bold);

            double y = 40;

            gfx.DrawString("Potwierdzenie przelewu", titleFont, XBrushes.Black,
                new XRect(0, y, page.Width, 30), XStringFormats.TopCenter);

            y += 50;

            void DrawRow(string label, string value)
            {
                gfx.DrawString(label, labelFont, XBrushes.Black, 40, y);
                gfx.DrawString(value, valueFont, XBrushes.Black, 200, y);
                y += 18;
            }

            DrawRow("Numer potwierdzenia:", confirmation.ConfirmationNumber);
            DrawRow("Data potwierdzenia:", confirmation.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
            DrawRow("Status transakcji:", transaction.Status.ToString());

            y += 10;

            DrawRow("Nadawca:", transaction.FromAccount);
            DrawRow("Odbiorca:", transaction.ToAccount);
            DrawRow("Tytuł:", transaction.Title);
            DrawRow("Kwota:", $"{transaction.Amount:0.00} {transaction.Currency}");
            DrawRow("Data księgowania:", transaction.BookingDate.ToString("yyyy-MM-dd"));

            using var ms = new MemoryStream();
            document.Save(ms, false);
            return ms.ToArray();
        }
    }
}
