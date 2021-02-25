using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Pirates.Controllers
{
    public class PlaylistController : Controller
    {
        Models.User currentUser;

        // GET: Playlist
        public ActionResult Index(Models.User user)
        {
            currentUser = user;

            currentUser.Playlists = currentUser.Playlists.OrderBy(i => i.ID).ToList();

            return View(currentUser.Playlists);
        }

        // GET: Playlist/Details/5
        public ActionResult Details(Guid id)
        {
            var selectedPlaylist = currentUser.Playlists.Where(s => s.ID == id).FirstOrDefault();

            return View(selectedPlaylist);
        }

        // GET: Playlist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlist/Create
        [HttpPost]
        public ActionResult Create(Models.Playlist newPlaylist)
        {
            try
            {
                // TODO: Add insert logic here
                newPlaylist.ID = Guid.NewGuid();
                currentUser.Playlists.Add(newPlaylist);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Playlist/Edit/5
        public ActionResult Edit(Guid id)
        {
            var selectedPlaylist = currentUser.Playlists.Where(s => s.ID == id).FirstOrDefault();

            return View(selectedPlaylist);
        }

        // POST: Playlist/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, Models.Playlist upPlaylist)
        {
            try
            {
                // TODO: Add update logic here
                var oldPlaylist = currentUser.Playlists.Where(s => s.ID == id).FirstOrDefault();
                currentUser.Playlists.Remove(oldPlaylist);
                currentUser.Playlists.Add(upPlaylist);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Playlist/Delete/5
        public ActionResult Delete(Guid id)
        {
            var selectedPlaylist = currentUser.Playlists.Where(s => s.ID == id).FirstOrDefault();

            return View(selectedPlaylist);
        }

        // POST: Playlist/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, Models.Playlist delPlaylist)
        {
            try
            {
                // TODO: Add delete logic here
                delPlaylist = currentUser.Playlists.Where(s => s.ID == id).FirstOrDefault();
                currentUser.Playlists.Remove(delPlaylist);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
