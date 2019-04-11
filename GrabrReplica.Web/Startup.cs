using AutoMapper;
using FluentValidation.AspNetCore;
using GrabrReplica.Application.Infrastructure;
using GrabrReplica.Application.Modules.Account.Commands.RegisterAccountCommand;
using GrabrReplica.Common;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Infrastructure;
using GrabrReplica.Infrastructure.Notifications;
using GrabrReplica.Infrastructure.Notifications.Models;
using GrabrReplica.Persistance;
using GrabrReplica.Web.Filters;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace GrabrReplica.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] { typeof(Application.Infrastructure.AutoMapper.AutoMapperProfile).GetTypeInfo().Assembly });

            ConfigureAuthorization(services);
            ConfigureAuthentication(services);
            var st = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<INotificationService, EmailNotificationService>();
            services.AddTransient<IEmailMessageGenerator, EmailMessageGenerator>();
            services.Configure<EmailSettings>(options => Configuration.GetSection("EmailSettings").Bind(options));
            services.Configure<AuthOptions>(options => Configuration.GetSection("AuthOptions").Bind(options));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(RegisterAccountCommandHandler).GetTypeInfo().Assembly);

            services.AddSingleton(Configuration);
            ConfigureIdentity(services);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(MyExceptionFilterAttribute));
                options.Filters.Add(typeof(ModelStateGlobalValidator));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterAccountCommandValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options => { options.SignIn.RequireConfirmedEmail = false; })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
            });
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme,
                    "Bearer");
                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["AuthOptions:Issuer"],
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.ASCII.GetBytes((Configuration["AuthOptions:Key"]))),
                        ValidateIssuerSigningKey = true
                    };
                });
        }

    }
}
