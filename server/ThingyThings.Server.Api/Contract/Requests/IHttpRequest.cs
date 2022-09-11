using MediatR;

namespace ThingyThings.Server.Api.Contract.Requests;

public interface IHttpRequest : IRequest<IResult>
{

}