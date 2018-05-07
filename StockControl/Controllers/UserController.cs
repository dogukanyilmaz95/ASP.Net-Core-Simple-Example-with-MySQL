using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockControl.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockControl.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        StockContext db = new StockContext();

        

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = db.User.ToList<User>();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            User user1 = new User();
            user1 = user;
            db.User.Add(user);
            db.SaveChanges();

            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            User oldUser = db.User.Where(t => t.Id == user.Id).FirstOrDefault();

            if (user.email == oldUser.email)
            {
                oldUser.name = user.name;
                oldUser.password = user.password;
                oldUser.surname = user.surname;
                oldUser.email = user.email;
                db.User.Update(oldUser);
                db.SaveChanges();
                return Ok(oldUser);

            }
            else
            {
                int i = db.User.Where(t => t.email == user.email).Count();
                if (i > 0)
                {
                    return BadRequest("Please Change your email");
                }
                else
                {
                    oldUser.name = user.name;
                    oldUser.password = user.password;
                    oldUser.surname = user.surname;
                    oldUser.email = user.email;
                    db.User.Update(oldUser);
                    db.SaveChanges();
                    return Ok(oldUser);
                }

            }


            
          
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] User user)
        {
            User user1 = db.User.Where(t => t.Id == user.Id).FirstOrDefault();
            db.User.Remove(user1);
            db.SaveChanges();
            return Ok("Succesful.");
        }
        
       
    }
}
