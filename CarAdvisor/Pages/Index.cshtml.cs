using CarAdvisor.Data;
using CarAdvisor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarAdvisor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IChatService m_chatService;

        public IndexModel(IChatService chatService)
        {
            m_chatService = chatService;
        }

        public JsonResult OnGetUserInput(string userInput)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                var response = m_chatService.Ask(userInput);
                return new JsonResult(response);
            }
            return new JsonResult("Please enter some text.");
        }

        public JsonResult OnPostUserInput([FromBody] IEnumerable<Message> userInput)
        {
            if (userInput == null)
            {
                return new JsonResult("Please enter some text.");
            }
            var response = m_chatService.Ask(userInput);
            return new JsonResult(response);
        }
    }
}
