using FluentValidation;

namespace Application.Components.Order.Queries.GetById;

public class GetByIdValidation : AbstractValidator<GetByIdRequest>
{
	public GetByIdValidation()
	{
		RuleFor(x => x.Id).NotNull();
	}
}