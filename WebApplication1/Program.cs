using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình Database PostgreSQL
builder.Services.AddDbContext<WebApplication1.Models.AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình SignalR cho thông báo thời gian thực (Real-time notification)
builder.Services.AddSignalR();

// Cấu hình CORS cho SignalR và API 2 chiều
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.SetIsOriginAllowed(_ => true)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// Cấu hình JWT Bearer Authentication
var jwtKey = builder.Configuration["Jwt:Key"] ?? "SecretKey_LandingPage_Sach_PauloCoelho_2026_Secure_Key_LongEnough";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "LandingPageApi";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "LandingPageClients";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Đăng ký tầng Repository
builder.Services.AddScoped(typeof(WebApplication1.Models.Repository.IRepository<>), typeof(WebApplication1.Models.Repository.Repository<>));
builder.Services.AddScoped<WebApplication1.Models.Repository.IAccountRepository, WebApplication1.Models.Repository.AccountRepository>();
builder.Services.AddScoped<WebApplication1.Models.Repository.IBookRepository, WebApplication1.Models.Repository.BookRepository>();
builder.Services.AddScoped<WebApplication1.Models.Repository.IOrderRepository, WebApplication1.Models.Repository.OrderRepository>();
builder.Services.AddScoped<WebApplication1.Models.Repository.IAdminNotificationRepository, WebApplication1.Models.Repository.AdminNotificationRepository>();

// Đăng ký tầng Service
builder.Services.AddScoped<WebApplication1.Models.Service.IAuthService, WebApplication1.Models.Service.AuthService>();
builder.Services.AddScoped<WebApplication1.Models.Service.IBookService, WebApplication1.Models.Service.BookService>();
builder.Services.AddScoped<WebApplication1.Models.Service.IOrderService, WebApplication1.Models.Service.OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

// Cho phép CORS cho SignalR
app.UseCors("CorsPolicy");

// Bắt buộc UseAuthentication phải đứng TRƯỚC UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

// Định tuyến SignalR Hub
app.MapHub<WebApplication1.Hubs.NotificationHub>("/hub/notifications");

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
