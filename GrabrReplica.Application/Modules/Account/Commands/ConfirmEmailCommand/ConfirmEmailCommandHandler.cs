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

namespace GrabrReplica.Application.Modules.Account.Commands.ConfirmEmailCommand
{
    public class ConfirmEmailCommandHandler : BaseAccountCommand, IRequestHandler<ConfirmEmailCommand, Unit>
    {
        public ConfirmEmailCommandHandler(
            ApplicationDbContext dbContext,
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

        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || user.EmailConfirmed)
                throw new EntityNotExistsException(nameof(User), null, "User not exists or email already confirmed");
            await _notificationService.SendConfirmationLinkAsync(user.Email, user.Id,
                await _userManager.GenerateEmailConfirmationTokenAsync(user));
            return Unit.Value;

        }
    }
}