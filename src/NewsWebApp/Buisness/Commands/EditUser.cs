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
            public CommandEdit(int id, bool isActivate)
            {
                Id = id;
                IsActivate = isActivate;
            }
            public int Id { get; set; }
            
            public bool IsActivate { get; set; }


        }
    }
}
