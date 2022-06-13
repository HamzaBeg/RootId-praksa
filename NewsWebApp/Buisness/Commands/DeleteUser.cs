using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace NewsWebApp.Buisness.Commands
{
    public class DeleteUser
    {
        public class CommandDelete : IRequest<string>
        {
            public int Id { get; set; }
        }
    }
}
