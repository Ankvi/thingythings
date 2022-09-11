using System;

namespace ThingyThings.Server.Api.Handlers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class PostEndpoint : BaseEndpoint
{
    public PostEndpoint(string template) : base("POST", template)
    {
    }
}