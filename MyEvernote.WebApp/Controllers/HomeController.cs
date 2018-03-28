using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using MyEvernote.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //BusinessLayer.Test test = new BusinessLayer.Test();
            //test.InsertTest();
            //test.UpdateTest();
            //test.DeleteTest();

            //View and model through CategoryController 
            //if (TempData["mm"] != null)
            //{
            //    return View(TempData["mm"] as List<Note>);
            //}

            NoteManager nm = new NoteManager();

            return View(nm.GetAllNote().OrderByDescending(x => x.ModifiedOn).ToList());
            //return View(nm.GetAllNotesQueryable().OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryId(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
                // return RedirectToAction("Index", "Home");
            }

            return View("Index", cat.Notes.OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult MostLiked()
        {
            NoteManager nm = new NoteManager();
            return View("Index", nm.GetAllNote().OrderByDescending(x => x.LikeCount).ToList());

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //loginControl and redirecting
            //saving user credentials in session

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "aaa")
                {
                    ModelState.AddModelError("", "Username is already in use.");

                }

                if (model.Email == "aa@aa.com")
                {
                    ModelState.AddModelError("", "Email address is already in use.");

                }

                foreach (var item in ModelState)
                {
                    //Has any error?
                    if (item.Value.Errors.Count > 0)
                    {
                        return View(model);
                    }
                }

                return RedirectToAction("RegisterOk");
            }

            //username check
            //email check
            //register
            //activation mail
            //

            return View(model);
        }

        public ActionResult RegisterOk()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult UserActivate(Guid activationId)
        {
            //user activation
            return View();
        }
    }
}