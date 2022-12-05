using LumaTasks.Repository;
using LumaTasks.Repository.Context;
using LumaTasks.Repository.Interfaces;
using LumaTasks.Services;
using LumaTasks.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AlunoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AlunoConnection")));
builder.Services.AddHostedService<SubscriberService>();

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAulaService, AulaService>();
builder.Services.AddScoped<IAulaRepository, AulaRepository>();
builder.Services.AddScoped<IPublishService, PublishService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
