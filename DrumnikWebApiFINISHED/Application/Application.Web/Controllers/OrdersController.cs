using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Data;
using Application.Models;
using Application.Web.Models;
using System.Text.RegularExpressions;

namespace Application.Web.Controllers
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Orders
        [HttpGet]
        public IHttpActionResult GetOrders()
        {
            var orders = this.db.Orders.Where(o => o.Checkdate > DateTime.Now).Select(OrderModel.FromOrder);
            if (orders == null)
            {
                return this.BadRequest("No such order!");
            }

            return this.Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        //[HttpPost]
        //public IHttpActionResult PostOrder(Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Orders.Add(order);
        //    db.SaveChanges();

        //    return this.Ok(order);
        //}

        // POST: api/Orders
        [HttpPost]
        public IHttpActionResult PostOrders(OrderModel model)
        {
            //string dateFormatter = "dd-MM-yyyy HH:mm:ss";

            string errorMessage;
            bool isModelValid = IsOrderModelValid(model, out errorMessage);

            if (!isModelValid)
            {
                return this.BadRequest(errorMessage);
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid order!");
            }

            var newOrder = new Order
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Phone = model.Phone,
                Email = model.Email,
                Brand = model.Brand,
                Registration = model.Registration,
                Maintenance = model.Maintenance,
                Checkdate = DateTime.Parse(model.Checkdate),
                Information = model.Information
            };

            this.db.Orders.Add(newOrder);
            this.db.SaveChanges();

            model.Id = newOrder.Id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return ResponseMessage(response);
        }

        private bool IsOrderModelValid(OrderModel order, out string errorMessage)
        {
            // CHECK FIRSTNAME
            if (string.IsNullOrEmpty(order.Firstname) || order.Lastname.Length < 3 || order.Firstname.Length > 50)
            {
                errorMessage = "Invalid Firstname";
                return false;
            }

            // CHECK LASTNAME
            if (string.IsNullOrEmpty(order.Lastname) || order.Lastname.Length < 3 || order.Lastname.Length > 50)
            {
                errorMessage = "Invalid Lastname";
                return false;
            }

            // CHECK PHONE NUMBER
            if (string.IsNullOrEmpty(order.Phone) || order.Phone.Length < 3 || order.Phone.Length > 18)
            {
                errorMessage = "Invalid Phone";
                return false;
            }

            string phone = order.Phone.Trim();
            Regex pattern = new Regex("[\t\r.+ )(]");
            pattern.Replace(phone, string.Empty);
            if (phone.Length < 7)
            {
                errorMessage = "Invalid Phone";
                return false;
            }

            // CHECK DATE
            DateTime reservationDate;
            if (!DateTime.TryParse(order.Checkdate, out reservationDate))
            {
                errorMessage = "Invalid Reservation Date";
                return false;
            }

            if (reservationDate < DateTime.Now)
            {
                errorMessage = "Invalid Reservation Date";
                return false;
            }

            if (IsDateTaken(reservationDate))
            {
                errorMessage = "Date Is Already Taken";
                return false;
            }

            // CHECK EMAIL
            if (string.IsNullOrEmpty(order.Email) || order.Email.Length < 3 || order.Email.Length > 50)
            {
                errorMessage = "Invalid Email";
                return false;
            }

            if (!Regex.IsMatch(order.Email, @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)", RegexOptions.IgnoreCase))
            {
                errorMessage = "Invalid Email Format";
                return false;
            }

            // CHECK BRAND
            if (string.IsNullOrEmpty(order.Brand) || order.Brand.Length < 3 || order.Brand.Length > 50)
            {
                errorMessage = "Invalid Brand";
                return false;
            }

            // CHECK REGISTRATION
            if (string.IsNullOrEmpty(order.Registration) || order.Registration.Length < 6 || order.Registration.Length > 10)
            {
                errorMessage = "Invalid Registration";
                return false;
            }

            // CHECK MAINTENANCE
            if (string.IsNullOrEmpty(order.Maintenance) || order.Maintenance.Length < 6 || order.Maintenance.Length > 100)
            {
                errorMessage = "Invalid Maintenance";
                return false;
            }

            // CHECK REGISTRATION
            if (!string.IsNullOrEmpty(order.Information) && order.Information.Length > 250)
            {
                errorMessage = "Too Much Additional Information";
                return false;
            }

            errorMessage = "No Error";
            return true;
        }

        private bool IsDateTaken(DateTime date)
        {
            int ordersWithSameDate = this.db.Orders.Count(o => o.Checkdate == date);
            if (ordersWithSameDate <= 0)
            {
                return false;
            }

            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.Id == id) > 0;
        }

        // PUT: api/Orders/5
        [HttpPut]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            return this.BadRequest("Update Operation Not Implemented!");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != order.Id)
            //{
            //    return BadRequest();
            //}

            //db.Entry(order).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OrderExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Orders/5
        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            return this.BadRequest("Delete Operation Not Implemented!");

            //Order order = db.Orders.Find(id);
            //if (order == null)
            //{
            //    return NotFound();
            //}

            //db.Orders.Remove(order);
            //db.SaveChanges();

            //return Ok(order);
        }
    }
}