using Microsoft.AspNetCore.Mvc;
using MyMoviesApp.Data;
using MyMoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoviesApp.Controllers
{
    public class MovieTypeController : Controller
    {
        //dependency injection to use data

        private readonly ApplicationDbContext _db;

        public MovieTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MovieType> objList = _db.MovieTypes;
            return View(objList);
        }

        //get-create
        public IActionResult Create()
        {
             return View();
        }




        //POST-Create (add movie types , save to db and return)
        [HttpPost]
        [ValidateAntiForgeryToken] //check if we have token to make the post request
        public IActionResult Create(MovieType obj)
        {
            if (ModelState.IsValid) //check models attributes
            {
                _db.MovieTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Not found");
            }
            var obj = _db.MovieTypes.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            _db.MovieTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //GET- Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MovieTypes.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);
        }

        //POST-Update (add movies , save to db and return)
        [HttpPost]
        [ValidateAntiForgeryToken] //check if we have token to make the post request
        public IActionResult Update(MovieType obj)
        {
            if (ModelState.IsValid) //check models attributes
            {
                _db.MovieTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }




        ////GET- Delete
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.Movies.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();

        //    }
        //    return View(obj);
        //}

        //GET- Delete






        ////POST- Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken] //check if we have token to make the post request
        //public IActionResult DeletePost(int? id)
        //{
        //    var obj = _db.Movies.Find(id);

        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Movies.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");

        //}



    }

}
