using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BakersController(ApplicationContext context) 
        {
            _context = context;
        }

        // GET /api/bakers
        [HttpGet]
        public IEnumerable<Baker> GetAll() 
        {
            // Auto-magically SELECTs data
            // from the Bakers table
            return _context.Bakers;         // SELECT * FROM "bakers"
        }

        // GET /api/bakers/:id
        [HttpGet("{id}")]
        public Baker GetById(int id) {
            // SELECT * FROM "bakers"
            // WHERE id = $1
            return _context.Bakers
                .SingleOrDefault(baker => baker.id == id);
        }

        // POST /api/bakers
        /*
        {
            "name": "Anwar"
        }
        */
        [HttpPost]
        public Baker Post(Baker baker) {
            // JSON req body is "deserialized" into a Baker model instance

            // INSERT INTO "baker" ....
            _context.Add(baker);
            _context.SaveChanges();

            // res.send(baker);
            
            return baker;
        }
    }
}
