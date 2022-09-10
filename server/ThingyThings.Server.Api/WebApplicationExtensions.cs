using System.Reflection;
using MediatR;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api;

public static class WebApplicationExtensions
{
    private static string GetTemplate(Handler handler, IEndpointAttribute endpoint) => string.Join('/', handler.Template, endpoint.Template);

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        return app;
    }
    
    public static WebApplication MapEndpoint<THandler, TRequest>(this WebApplication app)
        where TRequest : IRequest
        where THandler : IRequestHandler<TRequest>
    {
        var handler = typeof(THandler).GetCustomAttribute<Handler>();
        if (handler is null)
        {
            throw new ArgumentException($"Handler {nameof(THandler)} does not have a {nameof(Handler)} attribute");
        }

        var requestType = typeof(TRequest);
        var get = requestType.GetCustomAttribute<GetEndpoint>();
        if (get is not null)
        {
            app.MapGet(GetTemplate(handler, get), async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        }
        
        var post = requestType.GetCustomAttribute<PostEndpoint>();
        if (post is not null)
        {
            app.MapPost(GetTemplate(handler, post), async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        }

        return app;
    }
}