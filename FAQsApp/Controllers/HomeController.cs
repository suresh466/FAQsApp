using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using FAQsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FAQsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FaqContext context;

        public HomeController(ILogger<HomeController> logger, FaqContext ctx)
        {
            _logger = logger;
            // Initialize the context for database access
            context = ctx;
        }

        // Index action, with optional parameters for filtering
        public IActionResult Index(string activeCategory="all", string activeTopic="all")
        {
            // set the active category and topic for multiple filtering and for setting active link in nav
            ViewBag.ActiveCategory = activeCategory;
            ViewBag.ActiveTopic = activeTopic;

            // Initially get the list of categories and topics for populating the nav and list
            List<Category> categories = context.Categories.ToList();
            List<Topic> topics = context.Topics.ToList();

            // send the categories and topics to the view
            ViewBag.Categories = categories;
            ViewBag.Topics = topics;

            // Query the database for FAQs
            IQueryable<Faq> query = context.Faqs;
            // if the active category is not "all", filter the query
            if (activeCategory != "all")
            {
                query = query.Where(f => f.Category.CategoryId.ToLower() == activeCategory.ToLower());
            }
            // if the active topic is not "all", filter the query
            if (activeTopic != "all")
            {
                query = query.Where(f => f.Topic.TopicId.ToLower() == activeTopic.ToLower());
            }

            // Execute the query and send the result as model
            var faqs = query.ToList();
            return View(faqs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
