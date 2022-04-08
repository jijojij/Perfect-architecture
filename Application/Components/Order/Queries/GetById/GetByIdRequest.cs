using Application.Abstracts;

namespace Application.Components.Order.Queries.GetById;

public class GetByIdRequest : IQuery, ICacheable
{
	public int? Id { get; set; }
	public string Key => Id.ToString() ?? string.Empty;
}