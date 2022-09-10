namespace ThingyThings.Server.Api.Handlers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PostEndpoint : HttpAttribute, IEndpointAttribute
{
    public PostEndpoint(string template) : base(template)
    {
    }
}