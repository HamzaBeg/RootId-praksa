using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.Models;

namespace NewsWebApp.Buisness.Commands
{
   
    public class Registration
    {
        public class CommandRegister : IRequest<string>
        {
            public string Email { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Password { get; set; }
        }
    }
}
