using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitLift.Manager;
using MitLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitLift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarDBManager _dbManager;

        public CarsController(CorolabPraktikDBContext context)
        {
            _dbManager = new CarDBManager(context);
        }

        // GET: api/<CarController>
        [HttpGet]
        [Route("/api/[controller]/Accounts")]
        public ActionResult<List<Account>> GetAllAccounts()
        {
            IEnumerable<Account> accounts = _dbManager.GetAllAccounts();

            if (!accounts.Any())
            {
                return NotFound("No accounts here");
            }
            return Ok(accounts);
        }

        [HttpGet]
        //[Route("/api/Cars")]
        public ActionResult<List<Car>> GetAllCars([FromQuery] DateTime? dateTimeFilter)
        {
            IEnumerable<Car> cars = _dbManager.GetAllCars(dateTimeFilter);

            if (!cars.Any())
            {
                return NotFound("No cars here");
            }
            return Ok(cars);
        }

        // GET api/<CarController>/5
        //[HttpGet("{id}")]
        //[Route("/api/GetAccountByID")]
        //public ActionResult<Account> GetAccountByID(int id)
        //{
        //    Account account = _dbManager.GetAccountById(id);

        //    if (account == null)
        //    {
        //        return NotFound("No account with this id: " + id);
        //    }
        //    return Ok(account);
        //}

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public ActionResult<Account> GetCarByID(int id)
        {
            Car car = _dbManager.GetCarById(id);

            if (car == null)
            {
                return NotFound("No car with this id: " + id);
            }
            return Ok(car);
        }

        // POST api/<CarController>
        [HttpPost]
        [Route("/api/AccountPost")]
        public ActionResult<Account> PostAccount([FromBody] Account newAccount)
        {
            Account createdAccount = _dbManager.AddAccount(newAccount);
            return Ok(createdAccount);
        }

        // POST api/<CarController>
        //[HttpPost]
        //public ActionResult<Car> PostCar([FromBody] Car newCar)
        //{
        //    Car createdCar = _dbManager.AddCar(newCar);
        //    return Ok(createdCar);
        //}

        // PUT api/<CarController>/5
        [HttpPut]
        [Route("/api/UpdateAccountByID/{id}")]
        public Account PutAccount(int id, [FromBody] Account value)
        {
            if (value == null)
            {
                NotFound("no account with this id");
            }
            return _dbManager.UpdateAccount(id, value);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public Car PutCar(int id, [FromBody] Car value)
        {
            return _dbManager.UpdateCar(id, value);
        }

        //// DELETE api/<CarController>/5
        ////[HttpDelete("{id}")]
        ////public void Delete(int id)
        ////{
        ////}
    }
}

