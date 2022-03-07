using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDetailsService.middleware;
using UserDetailsService.Models;

namespace UserDetailsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        [HttpGet]
        public List<UserViewModel> Get()
        {
            return new BLayer().GetUsers( BLayer.ConnectionType.ORM);
        }
    }
}