using MediatR;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Handlers;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests;

[GetEndpoint("recipes")]
public record GetRecipesRequest : IHttpRequest
{

}