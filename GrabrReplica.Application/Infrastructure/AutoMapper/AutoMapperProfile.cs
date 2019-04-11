using AutoMapper;
using GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand;
using GrabrReplica.Application.Modules.Account.Commands.RegisterAccountCommand;
using GrabrReplica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
