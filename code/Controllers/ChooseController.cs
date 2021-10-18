using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Community.Controllers
{
    public class ChooseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}