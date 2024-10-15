using Microsoft.EntityFrameworkCore;
using Supplier1API.Data;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Supplier1DB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(conn));
builder.Services.AddDbContext<AppDBContext>
    (options => options.UseSqlServer(conn));
builder.Services.AddControllers();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Program));


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

app.UseAuthorization();

app.MapControllers();

app.Run();
