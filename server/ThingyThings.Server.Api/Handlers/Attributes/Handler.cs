namespace ThingyThings.Server.Api.Handlers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class Handler : HttpAttribute
{
    public Handler(string template) : base(template)
    {
    }
}