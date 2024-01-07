﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.IService;
using ThucTap.Application.Mapper;
using ThucTap.Application.Service;
using ThucTap.Infrastructure.Modules;
namespace ThucTap.Application.Modules
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddInfrastructureModule();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IKhoaService, KhoaService>();
            services.AddScoped<IMonService, MonService>();
            return services;
        }
    }
}