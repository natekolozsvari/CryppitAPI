using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace CryppitBackend
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
            services.AddControllers();
            services.AddHttpClient();
            services.AddTransient<CryptoListService>();
            services.AddTransient<InvestmentListService>();
            services.AddTransient<CryptoGraphService>();
            services.AddTransient<CryptoDetailService>();
            //services.AddTransient<DailyCryptoService>();
            services.AddTransient<UserService>();
            services.AddScoped<IFavoriteRepository, SQLFavoriteRepository>();
            services.AddScoped<IUserRepository, SQLUserRepository>();
            services.AddScoped<IInvestmentRepository, SQLInvestmentRepository>();
            services.AddScoped<IDailyRepository, SQLDailyRepository>();
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            });
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

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
