using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDetailsService.Models;
using UserDetailsService.middleware;

namespace UserDetailsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        
        public IEnumerable<UserViewModel> Get()
        {
            return new BLayer().GetUsers( BLayer.ConnectionType.SQLCLIENT);
        }



    }
}
