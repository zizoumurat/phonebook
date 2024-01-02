using MediatR;

namespace PersonService.Application.Messaging;
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}