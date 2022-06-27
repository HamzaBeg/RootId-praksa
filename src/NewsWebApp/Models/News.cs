using System;

namespace NewsWebApp.Models
{
    public class News
    {
        public News()
        {
            Date = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}