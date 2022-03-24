namespace Application.Components.Order.Queries.GetById;

public class GetByIdRequest : IQuery
{
	public int? Id { get; set; }
}