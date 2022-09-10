namespace ThingyThings.Server.Api.Handlers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class GetEndpoint : HttpAttribute, IEndpointAttribute
{
    public GetEndpoint(string template) : base(template)
    {
    }
}