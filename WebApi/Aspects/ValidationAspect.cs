using Application;
using FluentValidation;

namespace TestAtch.Aspects;

public class ValidationAspect<TRequest, TResponse> : IQueryHandler<TRequest,TResponse>
where TRequest: IQuery
where TResponse : IResponse
{
	private readonly IValidator<TRequest> _validator;
	private readonly IQueryHandler<TRequest, TResponse> _decorate;

	public ValidationAspect(IValidator<TRequest> validator,
		IQueryHandler<TRequest, TResponse> decorate)
	{
		_validator = validator;
		_decorate = decorate;
	}
	public TResponse Execute(TRequest request)
	{
		var res = _validator.Validate(request);
		if (!res.IsValid)
			throw new InvalidOperationException("kosyak");

		return _decorate.Execute(request);
	}
}