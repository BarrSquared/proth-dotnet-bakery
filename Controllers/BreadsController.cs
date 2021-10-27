using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // localhost:5000/api/breads
    public class BreadsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BreadsController(ApplicationContext context) {
            // console.log('bakers is', context.Bakers)
            // this._context = context
            _context = context;
        }

        /**
            {
                "id": 1,
                "name": "Edan's Sour",
                "description": "Very Sour Sourdough",
                "count": 17,
                "bakedById": 1,
                "bakedBy": {
                    "id": 1,
                    "name": "Edan",
                },
                "type": "Sourdough"
            },
        */
        [HttpGet]
        public IEnumerable<Bread> GetBreads() {
            return _context.Breads
                // Include ("Join") the `Baker bakedBy` property
                .Include(bread => bread.bakedBy);
        }

        // PUT /api/breads/:id
        /*
            {
                name: "Some new name"
            }
        */
        [HttpPut("{id}")]
        public Bread Put(int id, Bread bread) {
            // Our DB context needs to know the id of the bread to update
            bread.id = id;

            // Update the bread in the database
            _context.Update(bread);

            // Save DB changes
            _context.SaveChanges();

            // Send back the updated bread
            return bread;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            // Finding the bread by id, which we want to delete
            Bread bread = _context.Breads.SingleOrDefault(bread => bread.id == id); 

            // Remove that bread
            _context.Breads.Remove(bread);

            _context.SaveChanges();
        }
    }
}


//public static bool FindInArray(object[] a, object x)

/*

class ControllerBase {
    // Lots o' fancy code
    // to do all the low-level HTTP schtuff
    lowLevelHttpListener() {
        // validate 
        // convert JSON into model instances
        res = getBreads();
        // create an HTTP response body
        // Send it over the wires
        // beep beep boop 🤖
    }
}

class BreadController extends ControllerBase {

    constructor(stuff, and, things) {

    }

    getBreads() {
        return db.getBreads();
    }
}


let myController = new BreadController(stuff, and, things);
*/
