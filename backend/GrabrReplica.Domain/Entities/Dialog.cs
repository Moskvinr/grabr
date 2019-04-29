using System.Collections.Generic;

namespace GrabrReplica.Domain.Entities
{
    public class Dialog : BaseEntity
    {
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
        public List<Message> Messages { get; set; }
    }
}