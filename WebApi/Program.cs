using Application;
using Application.Abstracts;
using Application.Components.Order.Queries.GetAll;
using Application.Components.Order.Queries.GetById;
using Application.Components.Order.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Repositories.Libs.Cosmos;
using Repositories.Order;
using TestAtch.Aspects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var service = builder.Services;
service.AddSingleton<DocumentClient>();
service.AddMemoryCache();

// repositories
service.AddSingleton<IOrderRepository, OrderRepository>();

// query handlers
// get by id
service.AddSingleton<IValidator<GetByIdRequest>, GetByIdValidation>();
service.AddSingleton<IQueryHandler<GetByIdRequest, GetByIdResponse>, GetByIdHandler>();
// get all
service.AddSingleton<IQueryHandler<GetAllRequest, GetAllResponse>, GetAllHandler>();

// aspects
service.Decorate(typeof(IQueryHandler<,>), typeof(CacheAspect<,>));
// ToDo - register decorators only with their own validators
service.Decorate(typeof(IQueryHandler<,>), typeof(ValidationAspect<,>));


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