using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Business.Pipelines
{
    public class RequestValidationBehavior<Req, Res> : IPipelineBehavior<Req, Res> where Req : IRequest<Res>
    {
        private IEnumerable<IValidator<Req>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<Req>> validators)
        {
            _validators = validators;
        }

        public Task<Res> Handle(Req request, RequestHandlerDelegate<Res> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new(request);
            List<ValidationFailure> failures = _validators.Select(c=>c.Validate(context))
                                                .SelectMany(c=>c.Errors)
                                                .Where(f=>f !=null).ToList();      
            if(failures.Count() != 0)
                throw new ValidationException(failures);
            return next();
        }
    }
}
