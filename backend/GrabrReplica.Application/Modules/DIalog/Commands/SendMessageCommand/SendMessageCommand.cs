using System;
using MediatR;

namespace GrabrReplica.Application.Modules.Dialog.Commands.SendMessageCommand
{
    public class SendMessageCommand : IRequest
    {
        public int? DialogId { get; set; }
        public string MessageFrom { get; set; }
        public string MessageTo { get; set; }
        public string MessageBody { get; set; }
//        public DateTime SentTime { get; set; }
    }
}