using System.Collections.Generic;
using GrabrReplica.Application.Modules.Dialog.Models;
using MediatR;

namespace GrabrReplica.Application.Modules.Dialog.Queries.GetUserDialogsQuery
{
    public class GetUserDialogsQuery : IRequest<IEnumerable<DialogDto>>
    {
        public string UserId { get; set; }
    }
}