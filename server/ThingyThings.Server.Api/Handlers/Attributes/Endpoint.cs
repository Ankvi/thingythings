namespace ThingyThings.Server.Api.Handlers.Attributes;

public abstract class BaseEndpoint : Attribute
{
    public string HttpMethod { get; }
    public string Template { get; }

    protected BaseEndpoint(string httpMethod, string template)
    {
        HttpMethod = httpMethod;
        Template = template;
    }
}