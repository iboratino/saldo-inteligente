using FluentValidation.Results;
using MediatR;

namespace SaldoInteligente.Domain.Core.Commands
{
    public abstract class Command : IRequest
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }

    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
