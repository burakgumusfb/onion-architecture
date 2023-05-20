using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Onion.Architecture.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region AddSwagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Onion Architecture API",
                    Version = "v1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "burakgumusfb@gmail.com",
                    },
                    Description = "Burak Gümüş"
                });
            });
            #endregion

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            #region DbContext
            //services.AddDbContext<AdvancedFieldDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("AdvancedFieldDB")));
            #endregion

            #region Scoped
            services.AddHttpContextAccessor();
            #endregion

            #region Auth
            //services.ConfigureAuth(Configuration);
            #endregion

            services.AddControllers();
            services.AddMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdvancedField API V1");
            });
            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvc();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints
                .MapControllers()
                .RequireAuthorization();
            });


        }
    }
}