namespace Application;

public interface IQueryHandler<TRequest, TResponse>
	where TRequest: IQuery
	where TResponse: IResponse
{
	TResponse Execute(TRequest request);
}









public interface IResponse
{
}

public interface IQuery
{
}