using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Core.Domain_Service
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadAll();

        IEnumerable<Pet> ReadAllByType(string Type);

        Pet CreatePet(Pet pet);

        Pet DeletePet(int Id);

        Pet EditPet(Pet updatedPet);

        Pet FindById(int id);
        
        Pet FindPetByIdIncludeOwner(int id);

    }
}
