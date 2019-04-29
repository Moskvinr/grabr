using System;

namespace GrabrReplica.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string MessageBody { get; set; }
        public DateTime SentTime { get; set; }
        public Dialog Dialog { get; set; }
    }
}