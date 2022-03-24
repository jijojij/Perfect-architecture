namespace Application.Components.Order.Queries.GetAll;

public class GetAllHandler : IQueryHandler<GetAllRequest, GetAllResponse>
{
    public GetAllResponse Execute(GetAllRequest request)
    {
        return new GetAllResponse();
    }
}