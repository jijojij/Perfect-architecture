using Application;
using Application.Components.Order.Queries.GetById;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace TestAtch.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
	private readonly IQueryHandler<GetByIdRequest, GetByIdResponse> _handler;

	public OrderController(IQueryHandler<GetByIdRequest, GetByIdResponse> handler)
	{
		_handler = handler;
	}

	[HttpGet]
	public async Task<OrderDto> GetById([FromQuery] int? id)
	{
		await Task.CompletedTask;
		var res =  _handler.Execute(new GetByIdRequest() { Id = id });
		return new OrderDto() { Id = res.Order.Id };
	}

	[HttpPost]
	public IActionResult Save(OrderDto orderDto)
	{
		return Ok();
	}
}