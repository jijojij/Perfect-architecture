using Application;
using FluentValidation;

namespace TestAtch.Aspects;

public class ValidationAspect<TRequest, TResponse> : IQueryHandler<TRequest, TResponse>
    where TRequest : IQuery
    where TResponse : IResponse
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IQueryHandler<TRequest, TResponse> _decorate;

    public ValidationAspect(IEnumerable<IValidator<TRequest>> validators,
        IQueryHandler<TRequest, TResponse> decorate)
    {
        _validators = validators;
        _decorate = decorate;
    }

    public TResponse Execute(TRequest request)
    {
        if (!_validators.Any())
        {
            return _decorate.Execute(request);
        }
        
        var context = new ValidationContext<TRequest>(request);
        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);
        
        if (errorsDictionary.Any())
        {
            throw new InvalidOperationException("kosyak");
        }
        return _decorate.Execute(request);
    }
}