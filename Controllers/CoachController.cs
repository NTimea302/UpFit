using UpFit__main.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpFit__main.Migrations;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Entity.Core.Mapping;
using System.Web.Caching;

namespace UpFit__main.Controllers
{
    public class CoachController : Controller
    {
        private CodeFirstDb db = new CodeFirstDb();

        // GET: Coach
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Coach coach)
        {
            using (CodeFirstDb db = new CodeFirstDb())
            {
                var chc = db.coaches.SingleOrDefault(u => u.UserName == coach.UserName && u.Password == coach.Password);
                if (chc != null)
                {
                    Session["UserID"] = chc.CoachID.ToString();
                    Session["UserName"] = chc.UserName.ToString();
                    return RedirectToAction("VideoList");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password.");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddVideo(HttpPostedFileBase video)
        {
            using (CodeFirstDb db = new CodeFirstDb())
            {
                if (video.FileName != null)
                {
                    video.SaveAs(Server.MapPath("/Videofiles/" + video.FileName));
                    Video uploadVideo = new Video();
                    {
                        uploadVideo.Vname = video.FileName.Split('.')[0];
                        uploadVideo.Vpath = "/Videofiles/" + video.FileName;
                    };
                    db.videos.Add(uploadVideo);
                    db.SaveChanges();
                    return RedirectToAction("VideoList");
                }
            }
            return View("VideoList");
        }
        [HttpGet]
        public ActionResult VideoList()
        {
            using (CodeFirstDb db = new CodeFirstDb())
            {
                List<Video> Videolist = new List<Video>();
                foreach (Video video in db.videos)
                {
                    Video dbVideo = new Video();
                    {
                        dbVideo.Vname = video.Vname;
                        dbVideo.Vpath = video.Vpath.ToString();
                    };
                    Videolist.Add(dbVideo);
                }
                return View(Videolist);
            }
        }
    }
}