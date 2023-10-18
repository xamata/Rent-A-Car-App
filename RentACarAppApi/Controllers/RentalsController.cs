using Microsoft.AspNetCore.Mvc;
using RentACarAppLibrary.Data;

namespace RentACarAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IDatabaseData _db;

        public RentalsController(IDatabaseData db)
        {
            _db = db;
        }

        // GET: api/<RentalsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Rentals/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var carType = _db.GetCarTypeById(id);
            return carType.Make;
            //return $"{id}";
        }

        // POST api/<RentalsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RentalsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RentalsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
