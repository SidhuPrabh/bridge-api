using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bridge_api.Models.Sql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bridge_api.Models.Professionals;
using Newtonsoft.Json;

namespace bridge_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessionalsController : ControllerBase
    {
        [HttpGet]
        [Route("getcat")]
        public IActionResult GetCat()
        {
            CategorySql _CategorySql = new CategorySql();
            return Ok(_CategorySql.GetCatFromDB());
        }

        [HttpGet]
        [Route("search")]
        public IActionResult SearchPro([FromQuery] string cat, [FromQuery] string city)
        {
            ProSql _ProSql = new ProSql();
            List<Professional> ListReturned = _ProSql.GetProListByCategoryFromDB(cat, city);
            string json = JsonConvert.SerializeObject(ListReturned);
            return Ok(json);
        }
    }
}
