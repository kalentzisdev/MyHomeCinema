using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyMoviesApp.Data;
using MyMoviesApp.Models;
using MyMoviesApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        //dependency injection to use data

        private readonly ApplicationDbContext _db;

        public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> objList = _db.Movies;

            foreach(var obj in objList)
            {
                obj.MovieType = _db.MovieTypes.FirstOrDefault(u => u.Id == obj.MovieTypeID);
            }

            return View(objList);
        }

        //get-create
        public IActionResult Create()
        {
            //    IEnumerable<SelectListItem> TypeDropDown = _db.MovieTypes.Select(i => new SelectListItem
            //    {
            //        Text = i.Name,
            //        Value = i.Id.ToString()
            //    });

            //    ViewBag.TypeDropDown = TypeDropDown;  //parse data from controller to a view

            TypesVM typesVM = new TypesVM()
            {
                Movie = new Movie(),
                TypeDropDown = _db.MovieTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

             return View(typesVM);
        }




        //POST-Create (add movies , save to db and return)
        [HttpPost]
        [ValidateAntiForgeryToken] //check if we have token to make the post request
        public IActionResult Create(TypesVM obj)
        {
            if (ModelState.IsValid) //check models attributes
            {
               
                _db.Movies.Add(obj.Movie);
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
            var obj = _db.Movies.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            _db.Movies.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //GET- Update
        public IActionResult Update(int? id)
        {
            TypesVM typesVM = new TypesVM()
            {
                Movie = new Movie(),
                TypeDropDown = _db.MovieTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            typesVM.Movie = _db.Movies.Find(id);
            if (typesVM.Movie == null)
            {
                return NotFound();

            }
            return View(typesVM);
        }

        //POST-Update (add movies , save to db and return)
        [HttpPost]
        [ValidateAntiForgeryToken] //check if we have token to make the post request
        public IActionResult Update(TypesVM obj)
        {
            if (ModelState.IsValid) //check models attributes
            {
                _db.Movies.Update(obj.Movie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj.Movie);
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
