using MediatR;

namespace System.Threading.Tasks
{
    public class UpdateProfileCommand : IRequest
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}