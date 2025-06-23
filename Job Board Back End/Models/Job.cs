public class Job
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public List<Application> Applications { get; set; } = new();
}