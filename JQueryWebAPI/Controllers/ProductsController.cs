using JQueryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace JQueryWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        Product[] products = new Product[]
        {
            new Product {Id = 1, Name = "Bacon", Catagory = "Food", Price = 100},
            new Product {Id = 2, Name = "yo-yo", Catagory = "Toys", Price = 2.5M},
            new Product {Id = 3, Name = "Sonic Screwdriver", Catagory = "Hardware", Price = 148M}
        };

        /// <summary>
        /// Returns all the products in the array above.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }

        /// <summary>
        /// Searches the products using an ID.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            //This searches through the products and returns the first match that satisfies a condition. Returns null if no match is found. This is a Lambda Expression
            //is essentially a foreach loop written in a much more condensed way.
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}