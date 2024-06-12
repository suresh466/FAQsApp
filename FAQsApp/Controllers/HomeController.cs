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
            context = ctx;
        }

        public IActionResult Index(string activeCategory="all", string activeTopic="all")
        {

            ViewBag.ActiveCategory = activeCategory;
            ViewBag.ActiveTopic = activeTopic;

            List<Category> categories = context.Categories.ToList();
            List<Topic> topics = context.Topics.ToList();

            ViewBag.categories = categories;
            ViewBag.topics = topics;

            IQueryable<Faq> query = context.Faqs;
            if (activeCategory != "all")
            {
                query = query.Where(f => f.Category.CategoryId.ToLower() == activeCategory.ToLower());
            }
            if (activeTopic != "all")
            {
                query = query.Where(f => f.Topic.TopicId.ToLower() == activeTopic.ToLower());
            }

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
