using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.Buisness.Commands;
using NewsWebApp.Repositories;

namespace NewsWebApp.Buisness.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUser.CommandAdd, string>
    {
        private readonly IAuthenticatiRepository _authenticatiRepository;
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IAuthenticatiRepository authenticatiRepository, IUserRepository userRepository)
        {
            _authenticatiRepository = authenticatiRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(AddUser.CommandAdd command1, CancellationToken cancellationToken)
        {
            string message1 = "You have successfully added user!";
            string message2 = "User already exist!";
            if (await _authenticatiRepository.UserExists(command1.Email, cancellationToken) == true)
            {
                return message2;
            }
            await _userRepository.AddUser(command1.Email, command1.Password, command1.Ime,
                command1.Prezime, cancellationToken);
            return message1;

        }
    }
}
