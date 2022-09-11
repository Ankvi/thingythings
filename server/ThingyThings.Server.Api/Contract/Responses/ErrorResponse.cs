namespace ThingyThings.Server.Api.Contract.Responses;

public record ErrorResponse(string Message) : GeneralResponse(false, Message);