using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadFiles.Controllers
{
    public class UploadFilesController : Controller
    {
        [HttpGet]
        public ActionResult UploadFiles()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase[] files)
        {
            foreach (HttpPostedFileBase file in files)
            {


                if (file != null)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Uploads"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        ViewBag.UploadStatus = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.UploadStatus = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.UploadStatus = files.Count().ToString() + "You have not specified a file.";
                }
            }
            return View("UploadFiles");
        }
    }
}