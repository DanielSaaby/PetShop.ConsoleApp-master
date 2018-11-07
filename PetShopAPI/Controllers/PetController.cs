using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.ConsoleApp.Core.Application_Service;
using PetShop.ConsoleApp.Core.Entities;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }




        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            
                return _petService.ReadAll();
             
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.FindPetByIdIncludeOwner(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            return _petService.CreatePet(pet);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            pet.Id = id;
            return _petService.EditPet(pet);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return StatusCode(404, "Did not find Pet with ID " + id);
            }

            return Ok($"Pet with Id: {id} is Deleted");
        }

        private void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of all pets\n");
            foreach (var pet in pets)
            {
                Console.WriteLine($"" +
                    $"Id: {pet.Id} " +
                    $"\nName: {pet.Name} " +
                    $"\nType: {pet.Type} " +
                    $"\nBirthday: {pet.BirthDate} " +
                    $"\nSold(Date): {pet.SoldDate} " +
                    $"\nColor: {pet.Color} " +
                    $"\nPrevious Owner: {pet.Owner} " +
                    $"\nPrice: {pet.Price}");
            }
            Console.WriteLine("\n");
        }
    }
}
