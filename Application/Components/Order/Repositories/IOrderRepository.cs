namespace Application.Components.Order.Repositories;

public interface IOrderRepository
{
	Domain.Order GetById(int? id);
}