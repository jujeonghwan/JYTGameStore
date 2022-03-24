using JYTGameStore.Data;
using JYTGameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JYTGameStore.Controllers
{
    public class EmployeePanelController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeePanelController(ApplicationDbContext db) //dependency injection
        {
            dbContext = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Game> objList = dbContext.Game;
            return View(objList);
        }

        //Create Get: Go to Create view page 
        public IActionResult Create()
        {
            return View();
        }

        //Create Post: when the new game is added
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game gameObj)
        {
            //Validation of fields
            if (ModelState.IsValid)
            {
                dbContext.Game.Add(gameObj);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(gameObj);
            }

            
        }

        //Edit Get, for parameter, should use lowercase id
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NoContent();
            }
            else
            {
                var theGame = dbContext.Game.Find(id);
                if (theGame == null)
                {
                    return NoContent();
                }
                else
                {
                    return View(theGame);
                }
            }

            
        }

        //Edit Post: when the new game is edited
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Game gameObj)
        {
            //Validation of fields
            if (ModelState.IsValid)
            {
                dbContext.Game.Update(gameObj);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(gameObj);
            }
        }

        //Delete Get, for parameter, should use lowercase id
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NoContent();
            }
            else
            {
                var theGame = dbContext.Game.Find(id);
                if (theGame == null)
                {
                    return NoContent();
                }
                else
                {
                    return View(theGame);
                }
            }


        }

        //Delete Post: when the new game is deleted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int? gameId)
        {
            var theGame = dbContext.Game.Find(gameId);

            if (theGame == null)
            {
                return NoContent();
            }
            else
            {
                dbContext.Game.Remove(theGame);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}
