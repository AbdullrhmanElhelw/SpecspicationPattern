using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace SpecspicationPattern.Api.Utilities.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var errors = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .Distinct()
            .ToList();

        if (errors.Count != 0)
        {
            throw new ValidationException(errors);
        }

        return await next();
    }
}