using AutoMapper;
using BL;
using DAL.MySqlDbContext;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppy
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

            services.AddDbContext<DatabaseContext>(
                context => context.UseMySql(Configuration.GetConnectionString("Atempt2"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"))
            );

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IBankInstallmentService, BankInstallmentService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IOrderitemService, OrderitemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IResetpasswordService, ResetpasswordService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IShippingService, ShippingService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWishlistService, WishlistService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperBL());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IAddressBL, AddressBL>();
            services.AddScoped<IAdminBL, AdminBL>();
            services.AddScoped<IBankBL, BankBL>();
            services.AddScoped<IBankInstallmentBL, BankInstallmentBL>();
            services.AddScoped<IBasketBL, BasketBL>();
            services.AddScoped<IBrandBL, BrandBL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<ICityBL, CityBL>();
            services.AddScoped<IOrderitemBL, OrderitemBL>();
            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<IPageBL, PageBL>();
            services.AddScoped<IPaymentBL, PaymentBL>();
            services.AddScoped<IProductImageBL, ProductImageBL>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<IProvinceBL, ProvinceBL>();
            services.AddScoped<IResetpasswordBL, ResetpasswordBL>();
            services.AddScoped<ISettingBL, SettingBL>();
            services.AddScoped<IShippingBL, ShippingBL>();
            services.AddScoped<ISliderBL, SliderBL>();
            services.AddScoped<IUnitBL, UnitBL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IWishlistBL, WishlistBL>();

            services.AddCors();

            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
