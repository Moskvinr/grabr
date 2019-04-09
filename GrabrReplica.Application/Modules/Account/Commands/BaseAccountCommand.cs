using AutoMapper;
using AutoMapper.Configuration;
using MediatR;
using Microsoft.AspNetCore.Identity;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using GrabrReplica.Infrastructure.Notifications;

namespace GrabrReplica.Application.Modules.Account.Commands
{
    public abstract class BaseAccountCommand
    {
        protected readonly IConfiguration _configuration;
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;
        protected readonly INotificationService _notificationService;

        public BaseAccountCommand(
            ApplicationDbContext dbContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager, 
            IConfiguration configuration,
            IMapper mapper, 
            IMediator mediator,
            INotificationService notificationService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _mediator = mediator;
            _notificationService = notificationService;
        }
    }
}
