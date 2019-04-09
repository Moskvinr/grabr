using AutoMapper;
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
            LoadStandardMappings();
        }

        private void LoadStandardMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }
    }
}
