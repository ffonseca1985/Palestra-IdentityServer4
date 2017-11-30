using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ISMeetup.AppStart;
using ISMeetup.Infraestructure.MySqlEntityFramework.Contexts;
using ISMeetup.Infraestructure.MySqlEntityFramework.Repositories;
using ISMeetup.DomainModel;
using ISMeetup.Infraestructure;

namespace ISMeetup
{
    public class Startup
    {
        //dotnet ef migrations add testMigration
        //dotnet ef database update

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //.well-known/openid-configuration
            services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryClients(Config.GetClients())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddProfileService<IdentityWithAdditionalClaimsProfileService>();

            services.AddScoped<UserContext>();
            services.AddScoped<RepositoryBase<User>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();
        }
    }
}
