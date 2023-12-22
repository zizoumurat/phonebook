using MediatR;

namespace PersonService.Application.Messaging;
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}