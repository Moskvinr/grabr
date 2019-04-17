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

namespace GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordCommand
{
    public class ForgotPasswordCommandHandler : BaseAccountCommand, IRequestHandler<ForgotPasswordCommand>
    {
        public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new EntityNotExistsException(nameof(User), user, "user not exists");
            }

            await _notificationService.SendResetPasswordLinkAsync(user.Email, user.Id,
                await _userManager.GeneratePasswordResetTokenAsync(user));
            return Unit.Value;
        }

        public ForgotPasswordCommandHandler(ApplicationDbContext dbContext,
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
    }
}