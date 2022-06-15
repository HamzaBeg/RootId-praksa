using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Buisness.Queries
{
    public class GetAllUsers
    {
        public class Query : IRequest<List<LoginViewModel>>
        {
            public Query()
            {
            }

        }
    }
}
