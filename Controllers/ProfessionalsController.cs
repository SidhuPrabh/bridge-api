using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bridge_api.Models.Sql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}
