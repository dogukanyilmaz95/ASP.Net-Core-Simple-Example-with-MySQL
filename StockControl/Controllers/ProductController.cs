using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockControl.Models;

namespace StockControl.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        
            StockContext db = new StockContext();

            [HttpGet("GetAll")]
            public IActionResult GetAll()
            {
                List<Product> products = db.Product.ToList<Product>();
                return Ok(products);
            }

            [HttpPost]
            public IActionResult Create([FromBody] Product product)
            {
                Product prod = new Product();
                prod = product;
                db.Product.Add(prod);
                db.SaveChanges();

                return Ok(product);
            }

            [HttpPut]
            public IActionResult Update([FromBody] Product product)
            {
                Product oldProd = db.Product.Where(t => t.Id == product.Id).FirstOrDefault();

                if (product.code == oldProd.code)
                {
                    oldProd.name = product.name;
                    oldProd.code = product.code;
                    oldProd.quanitiy = product.quanitiy;
                    oldProd.price = product.price;
                    db.Product.Update(oldProd);
                    db.SaveChanges();
                    return Ok(oldProd);

                }
                else
                {
                    int i = db.Product.Where(t => t.code == product.code).Count();
                    if (i > 0)
                    {
                        return BadRequest("Please Change your code");
                    }
                    else
                    {
                        oldProd.name = product.name;
                        oldProd.code = product.code;
                        oldProd.quanitiy = product.quanitiy;
                        oldProd.price = product.price;
                        db.Product.Update(oldProd);
                        db.SaveChanges();
                        return Ok(oldProd);
                    }

                }




            }

            [HttpDelete]
            public IActionResult Delete([FromBody] Product product)
            {
                Product prod = db.Product.Where(t => t.Id == product.Id).FirstOrDefault();
                db.Product.Remove(prod);
                db.SaveChanges();
                return Ok("Succesful.");
            }


        }
    
}
