﻿using AutoMapper;
using AutoMapper.Configuration;
using MediatR;
using Microsoft.AspNetCore.Identity;
using GrabrReplica.Application.Exceptions;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Persistance;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Common;
using GrabrReplica.Infrastructure.Notifications;

namespace GrabrReplica.Application.Modules.Account.Commands.RegisterAccountCommand
{
    public class RegisterAccountCommandHandler : BaseAccountCommand, IRequestHandler<RegisterAccountCommand, Unit>
    {
        public RegisterAccountCommandHandler(
            ApplicationDbContext dbContext,
            UserManager<User> userManager,
            IMapper mapper,
            IMediator mediator,
            INotificationService notificationService)
            : base(dbContext,
                userManager,
                null,
                null,
                mapper,
                mediator,
                notificationService)
        {
        }

        public async Task<Unit> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var checkIfExist = _dbContext
                .Users
                .FirstOrDefault(x => x.Email == request.Email || x.UserName == request.UserName);
            if (checkIfExist != null)
                throw new EntityExistsException(nameof(User), checkIfExist.Id, "There is existing user with same email or username");

            var user = _mapper.Map<User>(request);
            await _userManager.CreateAsync(user, request.Password);
            user = await _userManager.FindByEmailAsync(request.Email);
            await _userManager.AddToRoleAsync(user, UserRoleNames.User);
            await _notificationService.SendConfirmationLinkAsync(user.Email, user.Id, await _userManager.GenerateEmailConfirmationTokenAsync(user));

            return Unit.Value;
        }
    }
}