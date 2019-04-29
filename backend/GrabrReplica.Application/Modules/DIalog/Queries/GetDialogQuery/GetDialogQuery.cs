using MediatR;

namespace GrabrReplica.Application.Modules.Dialog.Queries.GetDialogQuery
{
    public class GetDialogQuery : IRequest<int>
    {
        public string UserId { get; set; }
        
        public string InterlocutorId { get; set; }
    }
}