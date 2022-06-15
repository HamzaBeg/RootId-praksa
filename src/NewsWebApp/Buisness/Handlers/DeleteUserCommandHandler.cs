using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.Buisness.Commands;
using NewsWebApp.Enumerations;
using NewsWebApp.Repositories;

namespace NewsWebApp.Buisness.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUser.CommandDelete, string>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(DeleteUser.CommandDelete commandEdit, CancellationToken cancellationToken)
        {
            string message1 = "You have successfully deleted user!";
            string message2 = "User not found!";

            var user = await _userRepository.FindUser(commandEdit.Id, cancellationToken);

            if (user != null)
            {
                await _userRepository.DeleteUser(user,cancellationToken);
                return message1;
            }
            else
            {
                return message2;
            }
        }
    }
}
