using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasOilLiners.API.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly GasOilLinersContext _context;

        public AccountController(GasOilLinersContext context)
        {
            _context = context;
        }

    }
}