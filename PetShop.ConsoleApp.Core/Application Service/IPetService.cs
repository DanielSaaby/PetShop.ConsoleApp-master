using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Core.Application_Service
{
    public interface IPetService
    {
        Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, Owner previousOwner, double price);

        List<Pet> ReadAll();

        IEnumerable<Pet> ReadAllByType(string type);

        Pet CreatePet(Pet pet);

        Pet DeletePet(int Id);

        Pet EditPet(Pet pet);

        List<Pet> SortPetByPrice();

        List<Pet> Show5CheapestPets();

        Pet FindPetById(int id);

        Pet FindPetByIdIncludeOwner(int id);
    }
}
