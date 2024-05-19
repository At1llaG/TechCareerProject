using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechCareer.Website.Models;

namespace TechCareerProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly TechCareerDbContext _context;

        public HomeController(ILogger<HomeController> logger, TechCareerDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var expenses = _context.Expenses.ToList();
            
            var total = expenses.Sum(e => e.Value);
            
            ViewBag.Total = total;

            return View(expenses);
        }

        public IActionResult CreateEditExpense(int? id) {
            if (id.HasValue)
            {
                var expense = _context.Expenses.SingleOrDefault(e => e.Id == id);
                return View(expense);
            }


            return View();
        }

        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.SingleOrDefault(e => e.Id == id);
            _context.Expenses.Remove(expense);
            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }

            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
