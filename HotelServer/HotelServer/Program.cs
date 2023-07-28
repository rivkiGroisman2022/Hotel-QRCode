using HotelBL;
using HotelServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<EmailManager>();
// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBLServices();

var app = builder.Build();
//app.UseCors(policy => policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

//add cors permitions to angular
