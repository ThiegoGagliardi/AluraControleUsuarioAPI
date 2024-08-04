using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using AluraControleUsuarioAPI.Data;
using AluraControleUsuarioAPI.Models;
using AluraControleUsuarioAPI.Services;
using AluraControleUsuarioAPI.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration["ConnectionStrings:UserConnection"];

builder.Services.AddDbContext<UserDbContext>(opts => {opts.UseMySql(connectionString,
                                                      ServerVersion.AutoDetect(connectionString));});

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuthorization>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options => {
                                                options.DefaultAuthenticateScheme =   
                                                          JwtBearerDefaults.AuthenticationScheme;
                                               }).AddJwtBearer(options => {options.TokenValidationParameters = new TokenValidationParameters
                                                            {
                                                               ValidateIssuerSigningKey = true,
                                                               IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
                                                               ValidateAudience = false,
                                                               ValidateIssuer = false,
                                                               ClockSkew = TimeSpan.Zero
                                                              };
                                                         });


builder.Services.AddAuthorization(options => options.AddPolicy("MinimumAge", 
                                                               policy => policy.AddRequirements(new MinimumAge(18))));

builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<TokenService, TokenService>();

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