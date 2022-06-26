using AutoMapper;
using Company.Project.Core.ExceptionManagement;
using Company.Project.ProductDomain.AppServices;
using Company.Project.ProductDomain.AppServices.Mapper;
using Company.Project.ProductDomain.Configuration;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.Web.Data;
using Company.Project.Web.Interfaces;
using Company.Project.Web.Mapper;
using Company.Project.Web.Repository;
using Company.Project.Web.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Company.Project.Web
{
    public class Startup
    {
        private MapperConfiguration _mapperConfiguration { get; set; }
        private IExceptionManager exceptionManager;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddProfile(new WebMappingProfile());
            });

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;

            });

            //Password Related Validations
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            });

            services.AddControllersWithViews();
            services.AddDbContext<Data.EventContext>(
                options => options.UseSqlServer("Server=.;Database=BookReadingEvent;Integrated Security=True"));
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<EventContext>()
                    .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = Configuration["Application:LoginPath"];
            });

            //Registering Repositories and Services
            services.RegisterRepositories();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserService, UserService>();




            Company.Project.Core.Logging.ILogger logger = new Company.Project.Loggig.NLog.Logger();
            exceptionManager = new ExceptionManager(logger);
            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
            services.AddSingleton<IProductAppService, ProductAppService>();
            services.AddSingleton<IExceptionManager, ExceptionManager>();
            services.AddSingleton<Company.Project.Core.Logging.ILogger, Company.Project.Loggig.NLog.Logger>();            
            services.AddDbContext<ProductDomainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }
            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
