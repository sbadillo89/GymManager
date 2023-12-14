using System.Text;
using System.Text.Json.Serialization;
using GymManager.Api;
using GymManager.Entities.Config;
using GymManager.Entities.Enums;
using GymManager.Entities.Interfaces.Repositories;
using GymManager.Entities.Interfaces.Services;
using GymManager.Repositories;
using GymManager.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    // Configurar convenciones de ruta global
    options.Conventions.Add(new LowercaseControllerRouteConvention());
})
.AddJsonOptions((options) =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();

//Swagger config
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gym Manager API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = $@"JWT Authorization header using the Bearer scheme. 
                        \r\n\r\n Enter prefix (Bearer), space, and then your token. 
                        Example: 'Bearer 1231233kjsdlkajdksad'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
            Reference = new OpenApiReference{
                Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string [] { }
        }
    });
});


//Add JwtConfig
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

// Se agrega Authentication
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);

var tokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false,
    RequireExpirationTime = false,
    ValidateLifetime = true
};
builder.Services.AddSingleton(tokenValidationParameters); // se agregan para reutilizarlos
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = tokenValidationParameters;
    });

//se agrega identity user
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
                    options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<GymManagerDbContext>();

builder.Services.AddDbContext<GymManagerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GymManagerConnectionDB"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add repositories
builder.Services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
builder.Services.AddScoped<IGymRepository, GymRepository>();
builder.Services.AddScoped<DocumentTypeRepository>();
builder.Services.AddScoped<GymLocationRepository>();
builder.Services.AddScoped<MembershipCustomerRepository>();
builder.Services.AddScoped<MembershipTypeRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CashBoxRepository>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<CustomerDimensionRepository>();

// Add services
builder.Services.AddScoped<ITransactionTypeServcie, TransactionTypeServcie>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGymService, GymService>();
builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddScoped<IGymLocationService, GymLocationService>();
builder.Services.AddScoped<IMembershipTypeService, MembershipTypeService>();
builder.Services.AddScoped<IMembershipCustomerService, MembershipCustomerService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICashBoxService, CashBoxService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICustomerDimensionService, CustomerDimensionService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

/*Blazor*/
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
/*End Blazor*/

app.UseHttpsRedirection();

app.UseAuthentication();//Added
app.UseAuthorization();

app.MapControllers();

//Create intial roles
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = Enum.GetNames(typeof(EnumRoles));// new[] { "Admin", "Manager", "Employee" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

//Create intial user
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    var email = "admin@admin.com";
    var password = "GiStm#89";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.UserName = email;
        user.Email = email;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, EnumRoles.Admin.ToString());
    }
}

app.Run();

//Add trainer options