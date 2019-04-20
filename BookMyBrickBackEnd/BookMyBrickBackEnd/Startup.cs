using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyBrickDomain.Repository;
using BookMyBrickDomain.UserAccount;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BookMyBrickBackEnd
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
            services.AddCors(options =>
                {
                    options.AddPolicy(
                        "AllowSpecificOrigin",
                        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<UserRepoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("conn")));
            services.AddTransient<AccountManagement>();
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info
                                           {
                                               Version = "v1",
                                               Title = "My API",
                                               Description = "My First ASP.NET Core Web API",
                                               TermsOfService = "None",
                                               Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                                           });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    
            //}
            //else
            //{
            //    app.UseHsts();
            //}
            app.UseDeveloperExceptionPage();
            app.UseCors("AllowSpecificOrigin");
            //app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
        }
    }
}
