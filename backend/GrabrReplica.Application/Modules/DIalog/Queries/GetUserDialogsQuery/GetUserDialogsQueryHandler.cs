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
            var userDto = _mapper.Map<UserDto>(user);
            return user.Dialogs.Select(x =>
            {
                var secondUserDto = _mapper.Map<UserDto>(
                    _dbContext.Users.FirstOrDefault(u => u.Id == x.SecondUserId));
                return new DialogDto
                {
                    Id = x.Id,
                    FirstUser = userDto,
                    SecondUser = secondUserDto,
                    Messages = new List<MessageDto>
                    (
                        x.Messages.Select(m => new MessageDto
                        {
                            SentTime = m.SentTime,
                            MessageBody = m.MessageBody,
                            Id = m.Id
                        })
                    )
                };
            });
        }
    }
}