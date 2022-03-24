using Application.Components.Order.Repositories;

namespace Application.Components.Order.Queries.GetById;

public class GetByIdHandler : IQueryHandler<GetByIdRequest, GetByIdResponse>
{
	private readonly IOrderRepository _orderRepository;

	public GetByIdHandler(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	public GetByIdResponse Execute(GetByIdRequest request)
	{
		var order = _orderRepository.GetById(request.Id);
		return new GetByIdResponse(order);
	}
}