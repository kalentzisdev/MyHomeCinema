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
    public class SeriesController : Controller
    {
        //dependency injection to use data

        private readonly ApplicationDbContext _db;

        public SeriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Series> objList = _db.SeriesTV;

            foreach (var obj in objList)
            {
                obj.SeriesType = _db.MovieTypes.FirstOrDefault(u => u.Id == obj.MovieTypeId);
            }


            return View(objList);
        }

        //get-create
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.MovieTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.TypeDropDown = TypeDropDown;  //parse data from controller to a view
            TypesVM typesVM = new TypesVM()
            {
                Series = new Series(),
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
            if (ModelState.IsValid)
            {
                _db.SeriesTV.Add(obj.Series);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //GET- Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Not found");
            }
            var obj = _db.SeriesTV.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            _db.SeriesTV.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //GET- Update
        public IActionResult Update(int? id)
        {
            TypesVM typesVM = new TypesVM()
            {
                Series = new Series(),
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
            typesVM.Series = _db.SeriesTV.Find(id);
            if (typesVM.Series == null)
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
                _db.SeriesTV.Update(obj.Series);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }




        ////GET- Delete
        //public IActionResult Delete(int? Ιd)
        //{
        //    if (Ιd == null || Ιd == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.SeriesTV.Find(Ιd);
        //    if(obj == null)
        //    {
        //        return NotFound();

        //    }
        //    return View(obj);
        //}


        ////POST- Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken] //check if we have token to make the post request
        //public IActionResult DeletePost(int? SΙd)
        //{
        //    var obj = _db.SeriesTV.Find(SΙd);

        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.SeriesTV.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");

        //}
    }
}
