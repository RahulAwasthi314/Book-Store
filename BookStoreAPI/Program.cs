using BookStoreAPI.Data;
using BookStoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
//which one to use??
//builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddAutoMapper(typeof(StartupBase));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

builder.Services.AddDbContext<BookStoreContext>(options => 
    options.UseSqlServer(connectionString)
);

builder.Services.AddTransient<IBookRepository, BookRepository>();


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
