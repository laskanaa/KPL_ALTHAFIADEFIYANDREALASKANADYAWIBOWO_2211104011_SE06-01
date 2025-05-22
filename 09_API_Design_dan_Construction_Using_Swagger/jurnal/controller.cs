using Microsoft.AspNetCore.Mvc;
using modul9_2211104011.Models;

namespace modul9_2211104011.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Title = "Iron Man",
                Director = "Jon Favreau",
                Stars = new List<string> { "Robert Downey Jr", "Gwyneth Paltrow", "Terrence Howard" },
                Description = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil."
            },
            new Movie
            {
                Title = "Thor",
                Director = "Kenneth Branagh",
                Stars = new List<string> { "Chris Hemsworth", "Anthony Hopkins", "Natalie Portman" },
                Description = "The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders."
            }
        };

        [HttpGet]
        public ActionResult<List<Movie>> GetAll()
        {
            return movies;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            if (id < 0 || id >= movies.Count)
                return NotFound();

            return movies[id];
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie newMovie)
        {
            movies.Add(newMovie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= movies.Count)
                return NotFound();

            movies.RemoveAt(id);
            return Ok();
        }
    }
}