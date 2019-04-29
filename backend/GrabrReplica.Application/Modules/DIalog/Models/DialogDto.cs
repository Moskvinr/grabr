using System.Collections;
using System.Collections.Generic;

namespace GrabrReplica.Application.Modules.Dialog.Models
{
    public class DialogDto
    {
        public int Id { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
        public UserDto FirstUser { get; set; }
        public UserDto SecondUser { get; set; }
    }

    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}