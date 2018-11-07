using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.ConsoleApp.Core.Application_Service;
using PetShop.ConsoleApp.Core.Entities;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }


        // GET: api/Owner
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] Filter filter)
        {
            return Ok(_ownerService.GetFilteredOwners(filter));
            //return Ok(_ownerService.GetAllOwners());
        }

        // GET: api/Owner/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.FindOwnerByIdIncludePets(id);
        }

        // POST: api/Owner
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            return _ownerService.CreateOwner(owner);
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            return _ownerService.UpdateOwner(owner);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var owner = _ownerService.DeleteOwner(id);
            if (owner == null)
            {
                return StatusCode(404, "Did not find Owner with ID " + id);
            }

            return Ok($"Owner with Id: {id} is Deleted");
        }
    }
}
