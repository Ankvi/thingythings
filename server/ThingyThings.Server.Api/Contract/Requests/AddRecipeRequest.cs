using MediatR;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests;

[PostEndpoint("recipes")]
public class AddRecipeRequest : Recipe, IHttpRequest
{

}