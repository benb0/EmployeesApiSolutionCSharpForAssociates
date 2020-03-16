using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class StatusController : Controller
    {
        [HttpGet("/status")]
        public ActionResult GetTheServerStatus()
        {
            var response = new StatusResponse
            {
                Status = "Everything is running smoothly",
                CreatedAt = DateTime.Now
            };
            return Ok(response);
        }

        [HttpGet("/blogs/{year:int}/{month:int:range(1,12)}/{day:int:range(1,31)}")]
        public ActionResult GetBlogPost(int year, int month, int day) 
        {
            return Ok($"Getting you the blog posts for {month}/{day}/{year}");
        }

        [HttpGet("/tickets")]
        public ActionResult GetTickets([FromQuery] string status = "all")

        {
            return Ok($"Getting you the {status} tickets...");
        }

        [HttpPost("/status")]
        public ActionResult SetStatus([FromBody]StatusRequest request)
        {
            return Ok(request);
        }
    }

    public class StatusRequest
    {
        public string status { get; set; }
        public string setBy { get; set; }
    }

    public class StatusResponse
    {
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
