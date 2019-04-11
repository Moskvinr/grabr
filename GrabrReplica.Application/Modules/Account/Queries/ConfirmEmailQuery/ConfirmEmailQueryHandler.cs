using System;
using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Application.Exceptions;
using GrabrReplica.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GrabrReplica.Application.Modules.Account.Queries.ConfirmEmailQuery
{
    public class ConfirmEmailQueryHandler : IRequestHandler<ConfirmEmailQuery, Unit>
    {
        private readonly UserManager<User> _userManager;

        public ConfirmEmailQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new EntityNotExistsException(nameof(User), null, "User not exists");
            }

            await _userManager.ConfirmEmailAsync(user, request.Code);
            return Unit.Value;
        }
    }
}