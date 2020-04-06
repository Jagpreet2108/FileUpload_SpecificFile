using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _06April2020_2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _06April2020_2.Controllers
{
    public class FormUploadController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FormUploadController> _logger;
        public FormUploadController(ILogger<FormUploadController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(FormUpload formupload)
        {
            string strpath = System.IO.Path.GetExtension(formupload.myform.FileName);
            if (formupload.myform != null && (strpath == ".jpg" || strpath == ".jpeg" || strpath == ".gif" || strpath == ".png"))
            {
                {
                    string filepath = $"{_env.WebRootPath}/images/{formupload.myform.FileName}";
                    var stream = System.IO.File.Create(filepath);
                    formupload.myform.CopyTo(stream);
                    return Redirect("/FormUpload/Success");
                }
            }

             return Redirect("/FormUpload/Error");                     
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}