﻿using AutoMapper;
using AutoMapper.Configuration;
using GrabrReplica.Application.Exceptions;
using GrabrReplica.Application.Modules.Account.Models;
using GrabrReplica.Common;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Infrastructure.Notifications;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand
{
    public class LoginAccountCommandHandler :  IRequestHandler<LoginAccountCommand, TokenModel>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;
        private readonly AuthOptions _authOptions;

        public LoginAccountCommandHandler(
            IOptions<AuthOptions> authOptions,
            ApplicationDbContext dbContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            Microsoft.Extensions.Configuration.IConfiguration configuration,
            IMapper mapper,
            IMediator mediator,
            INotificationService notificationService)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
            _notificationService = notificationService;
            _authOptions = authOptions.Value;
        }

        public async Task<TokenModel> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            
            var identity = GetIdentity(user);

            return GetToken(identity);
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim("FirstName", user.FirstName),
                new Claim("SecondName", user.SecondName),
                new Claim("UserId", user.Id)
            };

            var userRoles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().ToList();
            userRoles.ForEach(x => claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, x)));

            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            if (claimsIdentity == null)
            {
                throw new NotFoundException(nameof(ClaimsIdentity), claimsIdentity);
            }

            return claimsIdentity;
        }

        private TokenModel GetToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(Convert.ToDouble(_authOptions.LifeTime))),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authOptions.SecretKey)),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenModel
            {
                AccessToken = encodedJwt,
                UserModel = new UserDataModel
                {
                    UserName = identity.Name,
                    FirstName = identity.Claims
                        .FirstOrDefault(x => x.Type == "FirstName")
                        ?.Value,
                    SecondName = identity.Claims
                        .FirstOrDefault(x => x.Type == "SecondName")
                        ?.Value,
                    UserId = identity.Claims
                        .FirstOrDefault(x => x.Type == "UserId")
                        ?.Value,
                    UserRoles = identity.Claims
                        .Where(c => c.Type == ClaimsIdentity.DefaultRoleClaimType)
                        .Select(x => x.Value)
                        .ToArray()
                }
            };
        }
    }
}