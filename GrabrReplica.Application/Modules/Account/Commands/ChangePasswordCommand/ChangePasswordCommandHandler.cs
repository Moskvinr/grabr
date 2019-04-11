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

namespace GrabrReplica.Application.Modules.Account.Commands.ChangePasswordCommand
{
    public class ChangePasswordCommandHandler : BaseAccountCommand, IRequestHandler<ChangePasswordCommand>
    {
        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user.EmailConfirmed)
            {
                await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            }

            throw new EmailNotConfirmedException(nameof(User), user);
        }

        public ChangePasswordCommandHandler(ApplicationDbContext dbContext,
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