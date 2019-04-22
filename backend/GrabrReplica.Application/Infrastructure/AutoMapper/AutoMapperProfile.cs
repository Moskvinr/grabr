using AutoMapper;
using GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand;
using GrabrReplica.Application.Modules.Account.Commands.RegisterAccountCommand;
using GrabrReplica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GrabrReplica.Application.Modules.Order.Models;
using GrabrReplica.Application.Modules.Order.Queries;
using GrabrReplica.Application.Modules.Profile.Models;

namespace GrabrReplica.Application.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // LoadStandardMappings();
            CreateMap<LoginAccountCommand, User>();
            CreateMap<User, LoginAccountCommand>();
            CreateMap<RegisterAccountCommand, User>();
            CreateMap<User, RegisterAccountCommand>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<User, OrderByDto>();
            CreateMap<OrderByDto, User>();
            CreateMap<ProfileDto, User>();
            CreateMap<User, ProfileDto>();
        }

        //private void LoadStandardMappings()
        //{
        //    var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

        //    foreach (var map in mapsFrom)
        //    {
        //        CreateMap(map.Source, map.Destination).ReverseMap();
        //    }
        //}
    }
}
