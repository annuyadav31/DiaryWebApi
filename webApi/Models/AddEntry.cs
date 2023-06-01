namespace webApi.Models
{
    public class AddEntry
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreationTime { get; set; }
        public string? Content { get; set; }
    }
}
