using FirstProject.Dtos;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private restaurantdbContext _resturantdbContext;
        public RestaurantController(restaurantdbContext resturantdbContext)
        {
            _resturantdbContext = resturantdbContext;
        }

        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _resturantdbContext.Restaurants.ToList();
            return Ok(result);
        }

        // GET api/<RestaurantController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult Create ([FromBody] CreateReastaurantDto dto)
        {
            var rest = new Restaurant();
            rest.Name = dto.Name;
            rest.PhoneNumber = dto.PhoneNumber;
            _resturantdbContext.Add(rest);
            _resturantdbContext.SaveChanges();
            return Ok(rest);

        }

        // PUT api/<RestaurantController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] UpdateReastaurantDto dto)
        {
            var rest =_resturantdbContext.Restaurants.Find(dto.Id);
            
            rest.Name = dto.Name;
            rest.PhoneNumber = dto.PhoneNumber;
            _resturantdbContext.Update(rest);
            _resturantdbContext.SaveChanges();
            return Ok(rest);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
