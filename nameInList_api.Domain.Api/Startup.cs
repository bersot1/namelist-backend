using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using nameInList_api.Domain.Handlers.ListaHandlers;
using nameInList_api.Domain.Handlers.UserHandlers;
using nameInList_api.Domain.Handlers.UserListaHandler;
using nameInList_api.Domain.Infra.Context;
using nameInList_api.Domain.Infra.Repositories;
using nameInList_api.Domain.Repositories;

namespace nameInList_api.Domain.Api
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();


            services.AddDbContext<DataContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddTransient<DataContext, DataContext>();
            services.AddTransient<IConnectionFactory, DeafultSqlConnectionFactory>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<CreateUserHandler, CreateUserHandler>();

            services.AddTransient<IListaRepository, ListaRepository>();
            services.AddTransient<CreateListaHandler, CreateListaHandler>();
            services.AddTransient<GetAllByIdCriatorHandler, GetAllByIdCriatorHandler>();
            services.AddTransient<GetByIdHandler, GetByIdHandler>(); 
            services.AddTransient<DeleteItemHandler, DeleteItemHandler>();

            services.AddTransient<IUserListaRepository, UserListaRepository>();
            services.AddTransient<CreateUserListaHandler, CreateUserListaHandler>();
            services.AddTransient<DeleteUserListHandler, DeleteUserListHandler>();
            //services.AddTransient<GetAllByIdCriatorHandler, GetAllByIdCriatorHandler>();
            //services.AddTransient<GetByIdHandler, GetByIdHandler>();


            //services.AddTransient<IListaRepository, IListaRepository>();
            //services.AddTransient<IUserListaRepository, IUserListaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Name in List ", Version = "v1", });
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
