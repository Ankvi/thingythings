using System.Reflection;
using MediatR;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api;

public static class WebApplicationExtensions
{
    public static WebApplication MapEndpoint<TRequest>(this WebApplication app)
        where TRequest : IRequest<IResult>
    {
        var requestType = typeof(TRequest);
        var endpoint = requestType.GetCustomAttribute<BaseEndpoint>();
        switch (endpoint)
        {
            case GetEndpoint get:
                app.MapGet(get.Template, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
                break;
            case PostEndpoint post:
                app.MapPost(post.Template, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
                break;
            default:
                throw new Exception($"Request '{requestType.Name}' does not contain an '{nameof(BaseEndpoint)}' attribute");
        }

        return app;
    }
}