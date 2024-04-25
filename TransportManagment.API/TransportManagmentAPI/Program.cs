
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;
using System.Net;
using System.Text;

using TransportManagmentInfrustructure.Data;
using Microsoft.EntityFrameworkCore;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentImplementation.DTOS.Authentication;
using TransportManagmentImplementation.Datas;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

//builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<ApplicationSetting>(builder.Configuration.GetSection("ApplicationSetting"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));



builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.User.RequireUniqueEmail = false)
                .AddEntityFrameworkStores<ApplicationDbContext>().
                AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
});

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddMvc().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase);
var emailSettings = builder.Configuration.GetSection("EmailSettings");
var defaultFromEmail = emailSettings["DefaultFromEmail"];
var host = emailSettings["SMTPSetting:Host"];
var port = emailSettings.GetValue<int>("SMTPSetting:Port");
var userName = emailSettings["SMTPSetting:UserName"];
var password = emailSettings["SMTPSetting:Password"];


var smtp = new SmtpClient
{
    Host = host,
    Port = port,
    EnableSsl = true,
    UseDefaultCredentials = false,
    DeliveryMethod = SmtpDeliveryMethod.Network,
    Credentials = new NetworkCredential(userName, password)
};


builder.Services.AddFluentEmail(defaultFromEmail)
    .AddSmtpSender(smtp);



builder.Services.AddCoreBusiness();


builder.Services.AddAutoMapper(typeof(AutoMapperConfigurations));


//Jwt Authentication

var key = Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSetting:JWT_Secret"].ToString());




builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtTokenOptions:Issuer"],
        ValidAudience = builder.Configuration["JwtTokenOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["JwtTokenOptions:SecretKey"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseDeveloperExceptionPage();

// Enable Swagger middleware if in development or production environment
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Integrated Digital Platforms"));
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors(cors =>
    cors.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
);

// Serve static files from wwwroot directory
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
    RequestPath = new PathString("/wwwroot")
});

// Enable authentication middleware
app.UseAuthentication();

// Use custom JWT token validation middleware
//app.UseJwtTokenValidationMiddleware();

// Map controllers
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();


