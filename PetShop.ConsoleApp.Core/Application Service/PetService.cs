using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.ConsoleApp.Core.Domain_Service;
using PetShop.ConsoleApp.Core.Entities;

namespace PetShop.ConsoleApp.Core.Application_Service
{
    public class PetService : IPetService
    {

        readonly IPetRepository _petRepository;
        readonly IOwnerRepository _ownerRepository;

        public PetService(IPetRepository petService, IOwnerRepository ownerRepository)
        {
            _petRepository = petService;
            _ownerRepository = ownerRepository;
        }


        public List<Pet> _pet = new List<Pet>();


        public Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                Owner = previousOwner,
                Price = price


            };
            return pet;
        }
        public Pet CreatePet(Pet pet)
        {
            
                return _petRepository.CreatePet(pet);
           

        }

        public Pet DeletePet(int id)
        {
            return _petRepository.DeletePet(id);
        }

        public Pet EditPet(Pet updatedPet)
        {
            var pet = FindPetById(updatedPet.Id);
            pet.Name = updatedPet.Name;
            _petRepository.EditPet(pet);
            return pet;
        }

        public List<Pet> ReadAll()
        {
            return _petRepository.ReadAll().ToList();
        }

        public IEnumerable<Pet> ReadAllByType(string type)
        {
            return _petRepository.ReadAllByType(type);
        }

        public List<Pet> Show5CheapestPets()
        {
            var listQueryPetCheapest = _petRepository.ReadAll();
            listQueryPetCheapest = listQueryPetCheapest.OrderBy(pet => pet.Price);
            return listQueryPetCheapest.Take(5).ToList();

            //return _petRepository.ReadAll().OrderBy(x => x.Price).Take(5).ToList();

        }

        public List<Pet> SortPetByPrice()
        {
            var listQueryPetPrice = _petRepository.ReadAll();
            listQueryPetPrice = listQueryPetPrice.OrderBy(pet => pet.Price);
            return listQueryPetPrice.ToList();
        }

        public Pet NewPet(string name, string type, string birthDate, string soldDate, string color, string previousOwner, string price)
        {
            throw new NotImplementedException();
        }

        public Pet FindPetById(int id)
        {
            var pet = _petRepository.FindById(id);
            if(pet.Owner != null)
            {
                pet.Owner = _ownerRepository.SortById(pet.Owner.id);
            }
            
            return pet;
        }

        public Pet FindPetByIdIncludeOwner(int id)
        {
            var pet = _petRepository.FindPetByIdIncludeOwner(id);
            return pet;
        }
    }
}
