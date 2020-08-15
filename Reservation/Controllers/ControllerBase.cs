using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Presentation.Controllers
{
    [SessionTimeout]
    public class ControllerBase : Controller
    {
        public readonly IWebHostEnvironment _hostingEnvironment;
        public ControllerBase()
        {

        }

        public ControllerBase(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
    }
}
