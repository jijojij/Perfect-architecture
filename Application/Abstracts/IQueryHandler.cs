namespace Application.Abstracts;

public interface IQueryHandler<TRequest, TResponse>
	where TRequest: IQuery
	where TResponse: IResponse
{
	TResponse Execute(TRequest request);
}