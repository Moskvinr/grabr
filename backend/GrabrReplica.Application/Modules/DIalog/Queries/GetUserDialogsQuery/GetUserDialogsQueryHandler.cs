using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrabrReplica.Application.Modules.Dialog.Models;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Dialog.Queries.GetUserDialogsQuery
{
    public class GetUserDialogsQueryHandler : IRequestHandler<GetUserDialogsQuery, IEnumerable<DialogDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserDialogsQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DialogDto>> Handle(GetUserDialogsQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(x => x.Dialogs)
                .ThenInclude(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            var dialog = await _dbContext.Dialogs
                .Include(x => x.Messages)
                .Where(x => x.Messages.Count > 0 && x.FirstUserId == request.UserId ||
                            x.SecondUserId == request.UserId)
                .ToListAsync(cancellationToken);
            var userDto = _mapper.Map<UserDto>(user);
            var dialogs = new List<DialogDto>();
            dialog.ForEach(x =>
            {
                var secondUser = _dbContext.Users.FirstOrDefault(y => y.Id == x.FirstUserId);
                if (secondUser != null && secondUser.Id == request.UserId)
                {
                    secondUser = _dbContext.Users.FirstOrDefault(e => e.Id == x.SecondUserId);
                }
//                var secondUserDto = _mapper.Map<UserDto>(
//                    _dbContext.Users.FirstOrDefault(u => u.Id == x.SecondUserId));
                dialogs.Add(
                    new DialogDto
                    {
                        Id = x.Id,
                        FirstUser = userDto,
                        SecondUser = _mapper.Map<UserDto>(secondUser),
                        Messages = new List<MessageDto>
                        (
                            x.Messages.Select(m => new MessageDto
                            {
                                SentTime = m.SentTime,
                                MessageBody = m.MessageBody,
                                Id = m.Id,
                                MessageFrom = m.MessageFrom
                            })
                        )
                    });
            });
            return dialogs;
        }
    }
}