using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VisionStore.Data;
using VisionStore.Helper;
using VisionStore.Models;
using VisionStore.Models.Webgentle.BookStore.Models;
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

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.RequireHttpsMetadata= false;
                                options.SaveToken = true;
                                options.TokenValidationParameters = new TokenValidationParameters()
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,               
                                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                    ValidAudience = builder.Configuration["Jwt:Audience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                                }; 
                            }
                            );
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews()
                            .AddNewtonsoftJson(options =>
                                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                              );

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    }
                    );
            });

            builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));

            builder.Services.AddDbContext<VisionStoreDbContext>(options =>
            {
                options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }) ;
            

            builder.Services.AddTransient<RoleRepository>();
            builder.Services.AddTransient<CustomerRepository>();
            builder.Services.AddScoped<UserMasterRepository>();
            builder.Services.AddTransient<PreferredPaymentMethodRepository>();            
            builder.Services.AddTransient<ManufacturerRepository>();            
            builder.Services.AddTransient<DiscountTableRepository>();            
            builder.Services.AddTransient<DeliveryRepository>();            
            builder.Services.AddTransient<ProductRepository>();            
            builder.Services.AddTransient<PurchaseRepository>();            
            builder.Services.AddTransient<PurchaseProductRepository>();            
            builder.Services.AddTransient<AddToCartRepository>();            
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
            builder.Services.AddTransient<Repository<Cart>>();
            builder.Services.AddTransient<EmailSenderRepository>();
            builder.Services.AddTransient<FileServiceRepository>();

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

            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .SetIsOriginAllowed(origin => true)
                                          .AllowAnyMethod());
            app.MapControllers();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }

        private class T
        {
        }
    }
}