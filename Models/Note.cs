namespace Laba4.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}