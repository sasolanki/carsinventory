using CarsInventory.Data;
using CarsInventory.Repository;
using CarsInventory.Web.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Web.Mvc;

namespace CarsInventory.Web.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private UnitOfWork unitOfWork;
        public CarsController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Cars
        public ActionResult Index()
        {
            return View(unitOfWork.CarsInventoryRepository.GetAll(User.Identity.GetUserId()));
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,Model,Year,Price,New")] Car car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Log.Info("Add Car started");

                    car.UserId = User.Identity.GetUserId();
                    unitOfWork.CarsInventoryRepository.Save(car);

                    Log.Info("Add Car completed");

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Log.Error("Error occurred while adding Car", ex);
                }
            }

            return View(car);
        }

        public ActionResult Edit(int id)
        {

            if (id == null)
            {
                Log.Error("Edit Car: Bad request");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = unitOfWork.CarsInventoryRepository.Get(id);

            if (car == null)
            {
                Log.Warn("Edit Car: Not found");
                return HttpNotFound();
            }
            
            
            return PartialView(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,Model,Year,Price,New,UserId")] Car car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Log.Info("Edit Car started");

                    unitOfWork.CarsInventoryRepository.Save(car);
                    Log.Info("Edit Car completed");

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Log.Error("Error occurred while editing Car", ex);
                }
            }
            return View(car);
        }



    }
}
