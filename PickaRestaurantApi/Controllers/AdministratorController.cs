using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickaRestaurantApi.Models;

namespace PickaRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private s16996Context _context;
        public AdministratorController(s16996Context context)
        {
            _context = context;
        }
    }
}