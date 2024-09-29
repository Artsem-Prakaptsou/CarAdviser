using CarAdvisor.Data;
using OpenAI.Chat;

namespace CarAdvisor.Services
{
    public class ChatService: IChatService
    {
        private readonly ChatClient m_client;

        public ChatService() {
            var key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            m_client = new ChatClient(model: "gpt-4o-mini", key);
        }
        public string Ask(string question)
        {
            // var answer = m_client.CompleteChat(question).Value.Content[0].Text;
            var answer = "test";
            return $"Answer: {answer}";
        }

        public string Ask(IEnumerable<Message> sonversation)
        {
            var messages = new List<ChatMessage>() 
            {
                new SystemChatMessage(@"You are helpful car adviser.
                Please guide me via set of questions (but no more then 5) in order to suggest car most appropriate for my needs.
                Please ask these questions one by one following user's answers and then provide your recommendation")
            };
            foreach (var message in sonversation)
            {
                messages.Add(message.Role== "user"?new UserChatMessage(message.Text.Length<2000? message.Text: message.Text.Substring(0, 200)):new AssistantChatMessage(message.Text));
            }

            var result= m_client.CompleteChat(messages, null);
            return result.Value.Content.First().Text;
        }
    }
}
