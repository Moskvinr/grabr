using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Application.Exceptions;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Dialog.Commands.SendMessageCommand
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public SendMessageCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            if (request.DialogId.HasValue && await _dbContext.Dialogs.AnyAsync(x => x.Id == request.DialogId.Value,
                    cancellationToken: cancellationToken))
            {
                var dialog = await
                    _dbContext
                        .Dialogs
                        .Include(x => x.Messages)
                        .FirstOrDefaultAsync(x => x.Id == request.DialogId.Value, cancellationToken);
                dialog.Messages.Add(GetMessage(request));
            }

            else if (!request.DialogId.HasValue && await _dbContext.Dialogs.AnyAsync(x =>
                             x.FirstUserId == request.MessageFrom || x.SecondUserId == request.MessageFrom,
                         cancellationToken))
            {
                var dialog = await _dbContext.Dialogs.FirstOrDefaultAsync(x =>
                    x.FirstUserId == request.MessageFrom || x.SecondUserId == request.MessageFrom, cancellationToken);
                dialog.Messages.Add(GetMessage(request));
            }
            else if (!request.DialogId.HasValue && !await _dbContext.Dialogs.AnyAsync(x =>
                             x.FirstUserId == request.MessageFrom || x.SecondUserId == request.MessageFrom,
                         cancellationToken))
            {
                await _dbContext.Dialogs.AddAsync(new Domain.Entities.Dialog()
                {
                    FirstUserId = request.MessageFrom,
                    SecondUserId = request.MessageTo,
                    Messages = new List<Message>()
                    {
                        GetMessage(request)
                    }
                }, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private Message GetMessage(SendMessageCommand request)
        {
            return new Message()
            {
                MessageBody = request.MessageBody,
                SentTime = DateTime.Now.ToString("G"),
                MessageFrom = request.MessageFrom
            };
        }
    }
}