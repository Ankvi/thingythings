namespace ThingyThings.Server.Api.Handlers.Attributes;

public abstract class HttpAttribute : Attribute
{
    protected HttpAttribute(string template)
    {
        Template = template;
    }
    
    public string Template { get; }
}