using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using System;
using System.IO;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpLoadsController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public FileUpLoadsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public string Post([FromForm] FileUpLoad objectFile)
        {
            try
            {
                if(objectFile.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + objectFile.files.FileName))
                    {
                        objectFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Uploaded success !.";
                    }
                }
                else
                {
                    return "Not Uploaded.";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
