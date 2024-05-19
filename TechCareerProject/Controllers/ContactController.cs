using Microsoft.AspNetCore.Mvc;

namespace TechCareerProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        //[BindProperty]
        //public FormModel Form { get; set; }

        //private readonly SendForward _sendForward;

        //public IndexModel(SendForward sendForward)
        //{
        //    _sendForward = sendForward;
        //}

        //// Property to store the message to display
        //[TempData]
        //public string DisplayMessage { get; set; }

        //public void OnGet()
        //{
        //    Form = new FormModel();
        //}

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    // Process form submission here
        //    _sendForward.StartSendingMessages(Form);

        //    DisplayMessage = "Form submitted successfully!";
        //    return Page();
        //}



    }
}
