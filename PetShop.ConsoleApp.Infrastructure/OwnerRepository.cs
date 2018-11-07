using PetShop.ConsoleApp.Core.Domain_Service;
using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PetShop.ConsoleApp.Infrastructure
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetAppContext _ctx;

        public OwnerRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner CreateOwner(Owner owner)
        {
           _ctx.Attach(owner).State = EntityState.Added;
            _ctx.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            //var petsToRemove = _ctx.Pets.Where(p => p.Owner.id == id);
            //_ctx.RemoveRange(petsToRemove);
            var ownerRemoved = _ctx.Remove(new Owner {id = id}).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }

        public IEnumerable<Owner> GetAllOwners(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Owners;
            }

            return _ctx.Owners
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);

        }

        public Owner SortById(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.id == id);
        }

        public Owner FindOwnerByIdIncludePets(int id)
        {
            return _ctx.Owners.Include(o => o.Pets).FirstOrDefault(o => o.id == id);
        }

        public Owner UpdateOwner(Owner updatedOwner)
        {
            throw new NotImplementedException();
        }
    }
}
