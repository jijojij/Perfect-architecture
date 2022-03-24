namespace Repositories.Libs.Cosmos.GenericRepository;

public class GenericRepository
{
	public T GetById<T>(int id)
	where T: new()
	{
		return new T();
	}
}