using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SiteCompras.Data;
using SiteCompras.Data.Dao;
using SiteCompras.Interfaces;
using SiteCompras.Models;
using SiteCompras.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Add services to the container.
builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddTransient<TokenService>();

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(connectionString);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => 
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("sdfdsfsd87fsd7fsd6fdf87sbhdfbhdf4hk")),
        ValidateIssuerSigningKey = true,
        ValidateAudience = false
    };
});


builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
   
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
