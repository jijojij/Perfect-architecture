using Application.Components.Order.Repositories;
using Repositories.Libs.Cosmos;
using Repositories.Models;

namespace Repositories.Order;

public class OrderRepository : IOrderRepository
{
	private readonly DocumentClient _documentClient;

	public OrderRepository(DocumentClient documentClient)
	{
		_documentClient = documentClient;
	}

	public Domain.Order GetById(int? id)
	{
		return _documentClient.Read<OrderDoc>(id);
	}
}