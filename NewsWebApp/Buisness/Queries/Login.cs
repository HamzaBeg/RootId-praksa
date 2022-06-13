using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.Models;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Buisness.Queries
{
    public class Login
    {
        public class Query : IRequest<LoginViewModel>
        {
            public Query()
            {
            }
            public Query(string email,string password)
            {
                Email = email;
                Password = password;

            }
            public string Email { get; }
            public string Password { get; }
        }
    }
}
