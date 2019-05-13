using System;

namespace GrabrReplica.Application.Modules.Dialog.Models
{
    public class MessageDto
    {
        public int Id { get; set; }
        
        public string MessageBody { get; set; }
        public string SentTime { get; set; }
        public string MessageFrom { get; set; }
    }
}