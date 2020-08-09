using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bridge_api.Models.Sql;

namespace bridge_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            LocationSql _locationSql = new LocationSql();
            return Ok(_locationSql.GetAllCitiesFromDB());
        }

        [HttpGet]
        [Route("getcity/{city}")]
        public IActionResult GetCity(string city)
        {
            LocationSql _locationSql = new LocationSql();
            return Ok(_locationSql.GetCityFromDB(city));
        }
    }
}
