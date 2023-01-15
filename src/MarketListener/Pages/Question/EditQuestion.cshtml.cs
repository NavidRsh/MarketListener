using MarketListener.Application.Features.Question.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketListener.Pages.Question
{
    public class EditQuestionModel : PageModel
    {
        [BindProperty]
        public UpdateQuestionCommand UpdateQuestionCommand { get; set; }
        public void OnGet()
        {
        }
    }
}
