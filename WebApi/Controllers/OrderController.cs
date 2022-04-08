using Application.Abstracts;
using Application.Components.Order.Queries.GetAll;
using Application.Components.Order.Queries.GetById;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace TestAtch.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
	private readonly IQueryHandler<GetByIdRequest, GetByIdResponse> _getByIdHandler;
	private readonly IQueryHandler<GetAllRequest, GetAllResponse> _getAllHandler;

	public OrderController(IQueryHandler<GetByIdRequest, GetByIdResponse> getByIdHandler, 
		IQueryHandler<GetAllRequest, GetAllResponse> getAllHandler)
	{
		_getByIdHandler = getByIdHandler;
		_getAllHandler = getAllHandler;
	}

	[HttpGet]
	public async Task<OrderDto> GetById([FromQuery] int? id)
	{
		await Task.CompletedTask;
		var res =  _getByIdHandler.Execute(new GetByIdRequest() { Id = id });
		return new OrderDto() { Id = res.Order.Id };
	}

	[HttpGet("all")]
	public Task<OrderDto[]> GetAll()
	{
		var res = _getAllHandler.Execute(new GetAllRequest());
		return Task.FromResult(Array.Empty<OrderDto>());
	}

	[HttpPost]
	public IActionResult Save(OrderDto orderDto)
	{
		return Ok();
	}
}