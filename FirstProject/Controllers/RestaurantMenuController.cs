using FirstProject.Dtos;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantMenuController : ControllerBase
    {
        private restaurantdbContext _resturantdbContext;
        public RestaurantMenuController(restaurantdbContext resturantdbContext)
        {
            _resturantdbContext = resturantdbContext;
        }
        // GET: api/<RestaurantMenuController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _resturantdbContext.Restaurantmenus.ToList();
            return Ok(result);
        }

        // GET api/<RestaurantMenuController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RestaurantMenuController>
        [HttpPost]
        public IActionResult Create([FromBody] CreateRestaurantMenuDto dto)
        {
            var rest = new Restaurantmenu();
            rest.RestaurantId = dto.RestaurantId;
            rest.MealName = dto.MealName;
            rest.PriceInNis = dto.PriceInNis;
            rest.PriceInUsd = dto.PriceInUsd;
            _resturantdbContext.Add(rest);
            _resturantdbContext.SaveChanges();
            return Ok(rest);

        }

        // PUT api/<RestaurantMenuController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateRestaurantMenuDto dto)
        {
            var rest = _resturantdbContext.Restaurantmenus.Find(dto.Id);

            rest.RestaurantId = dto.RestaurantId;
            rest.MealName = dto.MealName;
            rest.PriceInNis = dto.PriceInNis;
            rest.PriceInUsd = dto.PriceInUsd;
            _resturantdbContext.Update(rest);
            _resturantdbContext.SaveChanges();
            return Ok(rest);
        }

        // DELETE api/<RestaurantMenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
