using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using JournalApp.Models;

namespace JournalApp.Services
{
    public static class PdfExporter
    {
        public static byte[] GenerateJournalPdf(List<JournalEntry> entries)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);

                    page.Header().Text("Journal Entries")
                        .FontSize(20)
                        .Bold()
                        .AlignCenter();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(40);   // S.No
                            columns.RelativeColumn();     // Title
                            columns.RelativeColumn();     // Mood
                            columns.RelativeColumn();     // Category
                            columns.ConstantColumn(80);   // Date
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("S.No").Bold();
                            header.Cell().Text("Title").Bold();
                            header.Cell().Text("Mood").Bold();
                            header.Cell().Text("Category").Bold();
                            header.Cell().Text("Date").Bold();
                        });

                        int i = 1;
                        foreach (var e in entries)
                        {
                            table.Cell().Text(i++);
                            table.Cell().Text(e.Title);
                            table.Cell().Text(string.Join(", ",
                                e.EntryMoods.Select(m => m.Mood!.MoodName)));
                            table.Cell().Text(e.Tag?.TagName ?? "-");
                            table.Cell().Text(e.EntryDate.ToString("yyyy-MM-dd"));
                        }
                    });
                });
            }).GeneratePdf();
        }
    }
}
