using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
//checking shit
namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
            if(searchTerm != null)
            {
                if (searchType.Equals("all"))
                {
                    jobs = JobData.FindByValue(searchTerm);
                }
                else
                {
                    jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
            }
            else
            {
                if (searchType.Equals("all"))
                {
                    jobs = JobData.FindAll();
                }
            }
            ViewBag.jobs = jobs;
            ViewBag.title = "Search Results";
            ViewBag.Columns = ListController.columnChoices;
            return View("Index");
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
