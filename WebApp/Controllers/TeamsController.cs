using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class TeamsController : Controller
    {
        public static readonly List<Team> Teams = new List<Team>
        {
            new Team
            {
                Id = "PIT",
                Name = "Pittsburgh Penguins",
                Cups = 5,
                Captain = "Sidney Crosby",
                HeadCoach = "Mike Sullivan",
            },
            new Team
            {
                Id = "WSH",
                Name = "Washington Capitals",
                Cups = 0,
                Captain = "Alexander Ovechkin",
                HeadCoach = "Barry Trotz",
            }
        };

        public ActionResult Index()
        {
            return View(Teams);
        }

        public ActionResult Details(string id)
        {
            return View(Teams.Single(team => team.Id == id));
        }
    }

    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Cups { get; set; }
        public string Captain { get; set; }
        public string HeadCoach { get; set; }
    }
}