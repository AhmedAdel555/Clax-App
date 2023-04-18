using calx.Models;
using calx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace calx.Controllers
{
    public class CarController : Controller
    {
        private ApplicationDbContext _context;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("buy-cars")]
        // GET: Car
        public ActionResult Index()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }
        [Route("cars-detials/{Id}")]
        public ActionResult GetCarDetailes(int Id)
        {
            var car = _context.Cars.Include(x => x.Transmission).Include(x => x.CarStyle).Include(x => x.ApplicationUser).SingleOrDefault(x => x.Id == Id);
            if(car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [Route("add-car")]
        [Authorize]
        public ActionResult AddCarForm()
        {
            TransmisionsAndStylesCar transmisionsAndStylesCar = new TransmisionsAndStylesCar()
            {
                Car = new Car(),
                Transmissions = _context.Transmissions.ToList(),
                CarStyles = _context.CarStyles.ToList()

            };
            return View(transmisionsAndStylesCar);
        }

        [Route("edit-car/{Id}")]
        [Authorize]
        public ActionResult EditcarForm(int Id)
        {
            TransmisionsAndStylesCar transmisionsAndStylesCar = new TransmisionsAndStylesCar()
            {
                Car = _context.Cars.Include(x => x.Transmission).Include(x => x.CarStyle).SingleOrDefault(x => x.Id == Id),
                Transmissions = _context.Transmissions.ToList(),
                CarStyles = _context.CarStyles.ToList()
            };
            return View("AddCarForm", transmisionsAndStylesCar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(Car car)
        {
            if (!ModelState.IsValid)
            {
                TransmisionsAndStylesCar transmisionsAndStylesCar = new TransmisionsAndStylesCar()
                {
                    Car = car,
                    Transmissions = _context.Transmissions.ToList(),
                    CarStyles = _context.CarStyles.ToList()

                };
                return View("AddCarForm", transmisionsAndStylesCar);
            }
            if (car.Id == 0)
            {
                car.ApplicationUserId = _context.Users.FirstOrDefault(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name).Id;
                _context.Cars.Add(car);
            }
            else
            {
                var CarInDb = _context.Cars.SingleOrDefault(m => m.Id == car.Id);
                if(CarInDb.ApplicationUserId == _context.Users.FirstOrDefault(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name).Id || User.IsInRole("Admin"))
                {
                    CarInDb.Make = car.Make;
                    CarInDb.Model = car.Model;
                    CarInDb.Year = car.Year;
                    CarInDb.Color = car.Color;
                    CarInDb.ImgUrl = car.ImgUrl;
                    CarInDb.CarStyleId = car.CarStyleId;
                    CarInDb.TransmissionId = car.TransmissionId;
                    CarInDb.Price = car.Price;
                }
                else
                {
                    return Content("Error in server");
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Car");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteCar(Car car)
        {
            var ReturnedCar = _context.Cars.SingleOrDefault(c => c.Id == car.Id);

            if (ReturnedCar == null)
                return HttpNotFound();

            if(ReturnedCar.ApplicationUserId == _context.Users.FirstOrDefault(x => x.Email == System.Web.HttpContext.Current.User.Identity.Name).Id || User.IsInRole("Admin"))
            {
                _context.Cars.Remove(ReturnedCar);
                _context.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            return Content("Error in server");
        }
    }
}