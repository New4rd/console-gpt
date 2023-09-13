using OpenAI_API;
using OpenAI_API.Chat;

namespace ConsoleGPT.Services.Registrable.OpenAI;

/*
 * See documentation here:
 * https://github.com/OkGoDoIt/OpenAI-API-dotnet
 */

public class OpenAiService : IService
{
    private Conversation _defaultChat;
    
    public void Initialize(IServiceConfiguration configuration)
    {
        OpenAIAPI api = new OpenAIAPI(((OpenAiServiceConfiguration)configuration).ApiKey);
        _defaultChat = api.Chat.CreateConversation();
    }
    
    public async Task<string> SendChatMessage(string message)
    {
        _defaultChat.AppendUserInput(message);

        string chatResponse;
        try
        {
            chatResponse = await _defaultChat.GetResponseFromChatbotAsync();
        }
        catch (Exception exception)
        {
            chatResponse = exception.Message;
        }

        return chatResponse;
    }

    public IReadOnlyList<ChatMessage> GetConversationMessages()
    {
        return _defaultChat.Messages;
    }
}