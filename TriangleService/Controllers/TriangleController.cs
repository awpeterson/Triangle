using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriangleService.Models;
using Microsoft.Extensions.Logging;

namespace TriangleService.Controllers
{
    [Route("api/[controller]")]
    public class TriangleController : Controller
    {
        // POST api/values
        [HttpPost]
        public int Post([FromBody]Triangle value)
        {
            if(ModelState.IsValid){
                return (int) value.Type;
            }
            else{
                return (int) TriangleTypes.NOT_A_TRIANGLE;
            }
        }
    }
}
