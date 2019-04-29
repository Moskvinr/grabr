using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Dialog.Queries.GetDialogQuery
{
    public class GetDialogQueryHandler : IRequestHandler<GetDialogQuery, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetDialogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(GetDialogQuery request, CancellationToken cancellationToken)
        {
            var dialog = await _dbContext.Dialogs.FirstOrDefaultAsync(x =>
                    x.FirstUserId == request.UserId && x.SecondUserId == request.InterlocutorId ||
                    x.FirstUserId == request.InterlocutorId && x.SecondUserId == request.UserId,
                cancellationToken);
            if (dialog != null)
                return dialog.Id;
            var newDialog = new Domain.Entities.Dialog
            {
                FirstUserId = request.UserId,
                SecondUserId = request.InterlocutorId
            };
            await _dbContext.Dialogs.AddAsync(newDialog, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return newDialog.Id;
        }
    }
}