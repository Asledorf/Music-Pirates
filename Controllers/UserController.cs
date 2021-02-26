using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Pirates.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(Models.User.Users);
        }

        // GET: User/Details/5
        public ActionResult Details(Guid id)
        {
            var selectedUser = Models.User.Users.Where(u => u.ID == id).FirstOrDefault();

            return View(selectedUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(Models.User newUser)
        {
            try
            {
                // TODO: Add insert logic here
                newUser.ID = Guid.NewGuid();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(Guid id)
        {
            var selectedUser = Models.User.Users.Where(u => u.ID == id).FirstOrDefault();

            return View(selectedUser);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Models.User upUser)
        {
            try
            {
                // TODO: Add update logic here
                var oldUser = Models.User.Users.Where(s => s.ID == id).FirstOrDefault();
                Models.User.Users.Remove(oldUser);
                Models.User.Users.Add(upUser);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(Guid id)
        {
            var selectedUser = Models.User.Users.Where(u => u.ID == id).FirstOrDefault();

            return View(selectedUser);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, Models.User delUser)
        {
            try
            {
                // TODO: Add delete logic here
                delUser = Models.User.Users.Where(s => s.ID == id).FirstOrDefault();
                Models.User.Users.Remove(delUser);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
