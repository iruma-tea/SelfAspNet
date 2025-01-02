namespace SelfAspNet.Models;

public interface IRecordableTimestamp
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
