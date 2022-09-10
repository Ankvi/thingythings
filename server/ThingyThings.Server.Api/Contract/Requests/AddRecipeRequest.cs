using MediatR;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests;

[PostEndpoint("")]
public record AddRecipeRequest : IRequest<IResult>
{
    
}