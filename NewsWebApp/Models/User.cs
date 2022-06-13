using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewsWebApp.Enumerations;

namespace NewsWebApp.Models
{
    public class User
    {
       
        public int UserId { get; set; }

        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Status Status { get; set; }

        public bool IsActivate { get; set; }
        public ICollection<News> News { get; set; }
    }
}
