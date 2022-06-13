using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models
{
    public class News
    {
        public int NewId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
