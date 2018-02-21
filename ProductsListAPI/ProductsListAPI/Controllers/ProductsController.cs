using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ProductsListAPI.Models;

namespace ProductsListAPI.Controllers
{
    //Web API controllers are similar to MVC controllers, but inherit 
    //the ApiController class instead of the Controller class

    public class ProductsController : ApiController
    {
        //Product[] products = new Product[]
        //{
        //    new Product{Id = 1, Name = "Soup", Category = "Food", Price = 1.50M },
        //    new Product{Id = 2, Name = "Call of Duty 8", Category = "Toys", Price = 60M },
        //    new Product{Id = 3, Name = "Hammer", Category = "Hardware", Price = 6M },
        //    new Product{Id = 4, Name = "Brown Bread", Category = "Food", Price = 0.70M }
        //};

        static List<Product> products = new List<Product>()
        {
            new Product{Id = 1, Name = "Soup", Category = "Food", Price = 1.50M },
            new Product{Id = 2, Name = "Call of Duty 8", Category = "Toys", Price = 60M },
            new Product{Id = 3, Name = "Hammer", Category = "Hardware", Price = 6M },
            new Product{Id = 4, Name = "Brown Bread", Category = "Food", Price = 0.70M }
        };

        //GET get all products
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //GET - get a specific product
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }


        //POST - add a new product
        public IHttpActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var record = products.SingleOrDefault(p => p.Id == product.Id);
                if (record == null)
                {
                    products.Add(product);
                    string uri = Url.Link("DefaultApi", new { name = product.Name });         // name of default route in WebApiConfig.cs
                    return Created(uri, product);
                }
                else
                {
                    return BadRequest("Resource already exists");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        //PUT - update a product
        public IHttpActionResult PutUpdateProduct(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                if (id == product.Id)
                {
                    var record = products.SingleOrDefault(p => p.Id == id);
                    if (record == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        record.Name = product.Name;
                        record.Category = product.Category;
                        record.Price = product.Price;
                        return Ok(record);
                    }
                }
                else
                {
                    return BadRequest("invalid product");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }


        //DELETE - delete a product
        public IHttpActionResult DeleteProduct(int id)
        {
            var record = products.SingleOrDefault(p => p.Id == id);
            if (record != null)
            {
                products.Remove(record);
                return Ok(record);
            }
            else
            {
                return NotFound();
            }
        }
        
    }
}

/* Note

public IHttpActionResult GetProduct(int id)
var product = products.FirstOrDefault((p) => p.Id == id);

//SAME AS

foreach(var p in products)
{
       if(p.Id == id)
       {
            return p;
       }
}

*/
