using AutoMapper;
using AutoMapper.Configuration;
using GrabrReplica.Application.Exceptions;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Infrastructure.Notifications;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand
{
    public class LoginAccountCommandHandler : BaseAccountCommand, IRequestHandler<LoginAccountCommand, Unit>
    {
        public LoginAccountCommandHandler(AuthOptions authOptions, ApplicationDbContext dbContext, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IMapper mapper, IMediator mediator, INotificationService notificationService) : base(dbContext, userManager, signInManager, configuration, mapper, mediator, notificationService)
        {
        }

        public async Task<Unit> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var checkIfExist = _dbContext
                   .Users
                   .Where(x => x.Email == request.Email)
                   .FirstOrDefault();
            if (checkIfExist == null)
            {
                throw new EntityNotExistsException(nameof(User), null, "There is existing user with same email or username");
            }



            return Unit.Value;
        }
    }
}
