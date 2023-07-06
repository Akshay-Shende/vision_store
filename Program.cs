using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VisionStore.Data;
using VisionStore.Helper;
using VisionStore.Models;
using VisionStore.Repositories;

namespace VisionStore
{
    public class Program
    {
      

        public IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews()
                            .AddNewtonsoftJson(options =>
                                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                              );

            builder.Services.AddDbContext<VisionStoreDbContext>(options =>
            options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<RoleRepository>();
            builder.Services.AddTransient<CustomerRepository>();
            builder.Services.AddTransient<UserMasterRepository>();
            builder.Services.AddTransient<PreferredPaymentMethodRepository>();            
            builder.Services.AddTransient<ManufacturerRepository>();            
            builder.Services.AddTransient<DiscountTableRepository>();            
            builder.Services.AddTransient<DeliveryRepository>();            
            builder.Services.AddTransient<ProductRepository>();            
            builder.Services.AddTransient<PurchaseRepository>();            
            builder.Services.AddTransient<PurchaseProductRepository>();            
            builder.Services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            builder.Services.AddTransient<Repository<PreferredPaymentMethod>>();
            builder.Services.AddTransient<Repository<Roles>>();
            builder.Services.AddTransient<Repository<Customer>>();
            builder.Services.AddTransient<Repository<UserMaster>>();
            builder.Services.AddTransient<Repository<PreferredPaymentMethod>>();
            builder.Services.AddTransient<Repository<Manufacturer>>();
            builder.Services.AddTransient<Repository<DiscountTable>>();
            builder.Services.AddTransient<Repository<DeliveryMethods>>();
            builder.Services.AddTransient<Repository<Products>>();
            builder.Services.AddTransient<Repository<Purchase>>();
            builder.Services.AddTransient<Repository<PurchaseProducts>>();

            


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private class T
        {
        }
    }
}