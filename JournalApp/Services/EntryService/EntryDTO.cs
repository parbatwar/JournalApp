namespace JournalApp.Services.EntryService;

public class EntryDto
{
    public int? JournalId { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime EntryDate { get; set; }

    public int TagId { get; set; }
    public int PrimaryMoodId { get; set; }
    public int? SecondaryMoodId { get; set; }
}
