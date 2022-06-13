using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.Enumerations;

namespace NewsWebApp.Buisness.Commands
{
    public class EditUser
    {
        public class CommandEdit : IRequest<string>
        {
            public int Id { get; set; }
            
            public string Email { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public Role Role { get; set; }
            public Status Status { get; set; }
            public bool IsActivate { get; set; }


        }
    }
}
