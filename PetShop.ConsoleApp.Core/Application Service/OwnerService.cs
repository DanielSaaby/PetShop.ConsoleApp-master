using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.ConsoleApp.Core.Domain_Service;
using PetShop.ConsoleApp.Core.Entities;

namespace PetShop.ConsoleApp.Core.Application_Service
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public List<Owner> _owner = new List<Owner>();


        public Owner NewOwner(string firstName, string lastName, string address, string email, string phoneNumber, List<Pet> petsList)
        {
            var owner = new Owner()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                Pets = petsList
                


            };
            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.GetAllOwners().ToList();
        }

        public Owner SortById(int id)
        {
            return _ownerRepository.SortById(id);
        }

        public Owner FindOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepository.FindOwnerByIdIncludePets(id);
            return owner;
        }

        public List<Owner> GetFilteredOwners(Filter filter)
        {
            return _ownerRepository.GetAllOwners(filter).ToList();
        }

        public Owner UpdateOwner(Owner updatedOwner)
        {
            var owner = SortById(updatedOwner.id);
            owner.FirstName = updatedOwner.FirstName;
            owner.LastName = updatedOwner.LastName;
            owner.Address = updatedOwner.Address;
            owner.Email = updatedOwner.Email;
            owner.PhoneNumber = updatedOwner.PhoneNumber;
            
            return owner;
        }
    }
}
