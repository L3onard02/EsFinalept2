using Microsoft.EntityFrameworkCore;
using ProvaFinaleFaseB.DataSource;
using ProvaFinaleFaseB.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationLogContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("cnPostgres")));


builder.Services.AddScoped<ILogsRepository,LogsRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyCorsPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000/prodotto/");
            /*
                .AllowAnyOrigin() // Allow requests from any source
                .AllowAnyMethod() // Allow any HTTP method
                .AllowAnyHeader(); // Allow any HTTP headers
            */
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
