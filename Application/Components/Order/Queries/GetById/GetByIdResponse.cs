namespace Application.Components.Order.Queries.GetById;

public class GetByIdResponse : IResponse
{
	public GetByIdResponse(Domain.Order order)
	{
		Order = order;
	}

	public Domain.Order Order { get; }
}