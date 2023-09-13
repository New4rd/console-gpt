namespace ConsoleGPT.Services.Registrable.OpenAI;

public record OpenAiServiceConfiguration(string ApiKey) : IServiceConfiguration;