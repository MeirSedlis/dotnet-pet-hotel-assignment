using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return _context.PetOwners;
        }

        [HttpPost]
        public PetOwner Post (PetOwner petOwner)
        {
            _context.Add(petOwner);
            _context.SaveChanges();

            return petOwner;
        }

        [HttpDelete("{id}")]
        public ActionResult<PetOwner> Delete(int id)
        {
        PetOwner petOwner = _context.PetOwners
            .SingleOrDefault(petOwner => petOwner.id == id);

        if (petOwner is null)
        {
          return NotFound();
        }
        // Tell the DB that we want to remove this bread
        _context.PetOwners.Remove(petOwner);

        // ...and save the changes to the database
        _context.SaveChanges();

        // return the deleted bread, why not?
        return petOwner;
        }
    }
}
