
namespace SelfAspNet.Models;

public class Article : IRecordableTimestamp
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Url { get; set; } = String.Empty;
    public string Category { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
