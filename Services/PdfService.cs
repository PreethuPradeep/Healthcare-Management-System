using HealthCare.Models;
using QuestPDF.Fluent;

namespace HealthCare.Services
{
    public class PdfService
    {
        public byte[] GenerateBillPdf(PharmacyBill bill)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Content().Text($"Bill No: {bill.PharmacyBillId}\n" +
                                        $"Date: {bill.BillDate}\n" +
                                        $"Total: {bill.Total}");
                });
            }).GeneratePdf();
        }
    }
}
