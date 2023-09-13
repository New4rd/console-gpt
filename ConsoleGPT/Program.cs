using ConsoleGPT.Services;
using ConsoleGPT.Services.Registrable.OpenAI;

namespace ConsoleGPT;

public abstract class Program
{
    private static async Task Main()
    {
        string? openAiKey = "";
        while (openAiKey == null || string.IsNullOrEmpty(openAiKey) || string.IsNullOrWhiteSpace(openAiKey))
        {
            Console.WriteLine("Enter your OpenAI API Key: ");
            openAiKey = Console.ReadLine();
        }
        
        ServiceManager.RegisterService(new OpenAiService(), new OpenAiServiceConfiguration(openAiKey), true);

        while (true)
        {
            Console.WriteLine("Enter your prompt: ");
            string? message = Console.ReadLine();
            if (message == null || string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
                continue;

            var response = await ServiceManager.GetService<OpenAiService>()?.SendChatMessage(message)!;
            Console.WriteLine(response);
        }
    }
}