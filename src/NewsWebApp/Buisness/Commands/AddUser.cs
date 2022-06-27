using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace NewsWebApp.Buisness.Commands
{
    public class AddUser
    {
        public class CommandAdd : IRequest<string>
        {
            public CommandAdd(string email,string ime, string prezime,string password)
            {
                Email = email;
                Ime = ime;
                Prezime =prezime;
                Password=password;
            }
            public string Email { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Password { get; set; }
        }
    }
}
