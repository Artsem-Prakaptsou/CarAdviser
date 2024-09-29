using CarAdvisor.Data;

namespace CarAdvisor.Services
{
    public interface IChatService
    {
        string Ask(string question);
        string Ask(IEnumerable<Message> sonversation);
    }
}
