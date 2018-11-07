using PetShop.ConsoleApp.Core.Domain_Service;
using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PetShop.ConsoleApp.Infrastructure
{
    public class PetRepository : IPetRepository
    {
        readonly PetAppContext _ctx;

        public PetRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            /*if (pet.Owner != null)
            {
                _ctx.Attach(pet.Owner);
            }

            var saved = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return saved;*/
            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var petRemoved = _ctx.Remove(new Pet { Id = id }).Entity;
            _ctx.SaveChanges();
            return petRemoved;
        }

        public Pet EditPet(Pet updatedPet)
        {
            var petFromDB = FindById(updatedPet.Id);
            if (petFromDB == null) return null;

            petFromDB.Name = updatedPet.Name;
            
            return updatedPet;
        }

        public Pet FindById(int id)
        {
            return _ctx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet FindPetByIdIncludeOwner(int id)
        {
            return _ctx.Pets.Include(p => p.Owner).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets;
        }

        public IEnumerable<Pet> ReadAllByType(string Type)
        {
            throw new NotImplementedException();
        }
    }
}
