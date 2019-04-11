using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrabrReplica.Application.Exceptions;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Infrastructure.Notifications;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordUpaderCommand
{
    public class ForgotPasswordUpaderCommandHandler : BaseAccountCommand, IRequestHandler<ForgotPasswordUpaderCommand>
    {
        public ForgotPasswordUpaderCommandHandler(ApplicationDbContext dbContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration,
            IMapper mapper,
            IMediator mediator,
            INotificationService notificationService) : base(dbContext,
            userManager,
            signInManager,
            configuration,
            mapper,
            mediator,
            notificationService)
        {
        }

        public async Task<Unit> Handle(ForgotPasswordUpaderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new EntityNotExistsException(nameof(User), user, "User not exists");
            }

            await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            return Unit.Value;
        }
    }
}