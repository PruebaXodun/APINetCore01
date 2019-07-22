using Application.AppServices;
using Application.Profiles;
using AutoMapper;
using Domain.Aggregates;
using Domain.Seedwork;
using Infrastructure.Crosscutting;
using Infrastructure.Crosscutting.Adapter;
using Infrastructure.Crosscutting.AutoMapper;
using Infrastructure.Data.Context.MiTienda;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Seedwork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Services;

namespace APINetCore01
{
    public class Startup
    {
        private AplicattionSettting AplicattionSettting { get; }
        //private AutomapperTypeAdapterFactory AutomapperTypeAdapterFactory { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment Environment)
        {
            Configuration = configuration;
            AplicattionSettting = NewAplicattionSettting(Environment.EnvironmentName);
            //AutomapperTypeAdapterFactory = new AutomapperTypeAdapterFactory();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddDbContext<MiTiendaDbContext>(options => options.UseSqlServer(AplicattionSettting.ConnectionString));

            services.AddSingleton(AplicattionSettting);

            //Resgistro de automapper
            //Mapper.Initialize(cfg => cfg.AddProfile<ArticuloProfile>());
            //services.AddAutoMapper();
            //AutomapperTypeAdapterFactory

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ArticuloProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IMapper<Application.DTO.ArticuloDTO, Articulo>), typeof(ArticuloMapper));
            services.AddTransient<IArticuloService, ArticuloService>();
            services.AddTransient<IArticuloRepository, ArticuloRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private AplicattionSettting NewAplicattionSettting(string environmentName)
        {
            return new AplicattionSettting
            {
                AplicationVersion = Configuration.GetValue<string>("Version"),
                ConnectionString = Configuration.GetConnectionString("MiTienda"),
                Environment = environmentName
            };
        }
    }
}