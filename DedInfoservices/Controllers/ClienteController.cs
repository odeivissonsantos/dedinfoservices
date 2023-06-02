using DedInfoservices.Filters.Sessao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class ClienteController : Controller
    {      
        public IActionResult Index()
        {
            return View();
        }
    }
}
