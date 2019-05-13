using System;

namespace GrabrReplica.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string MessageBody { get; set; }
        public string SentTime { get; set; }
        public string MessageFrom { get; set; }
        public Dialog Dialog { get; set; }
    }
}