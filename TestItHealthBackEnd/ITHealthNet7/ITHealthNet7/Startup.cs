using Infraestructure.Helper;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace ITHealthNet7
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup( IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {

            //Cors

            //services.AddCors(o =>
            //{
            //    o.AddPolicy("Cors",
            //     builder => builder.WithOrigins("http://localhost:4200")
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     ); 
            //});

            // Add services to the container.

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DataBase")));
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public void configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            // Configure the HTTP request pipeline.
            app.UseSwagger();

            app.UseSwaggerUI();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseCors("Cors");
            app.UseHttpsRedirection();        

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(e =>
            {
                e.MapControllers();
            });

        }
    }
}
