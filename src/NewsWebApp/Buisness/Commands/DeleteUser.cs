using MediatR;

namespace NewsWebApp.Buisness.Commands
{
    public class DeleteUser
    {

        public class CommandDelete : IRequest<string>
        {
            public CommandDelete(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }
    }
}
