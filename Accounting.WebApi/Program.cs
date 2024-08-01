using Accounting.Application.Services.AppServices;
using Accounting.Domain.AppEntities.Identity;
using Accounting.Persistance.Context;
using Accounting.Persistance.Services.AppServices;
using Accounting.Presentation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddAutoMapper(typeof(Accounting.Persistance.AssemblyReference).Assembly);

//builder.Services.AddMediatR(typeof(Accounting.Application.AssemblyReference).Assembly);

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(Accounting.Application.AssemblyReference).Assembly));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly)
    //Controller artık presentation katmanından kullancağız
    ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurtySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurtySheme.Reference.Id, jwtSecurtySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            jwtSecurtySheme, Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
