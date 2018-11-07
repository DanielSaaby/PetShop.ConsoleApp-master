using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Core.Domain_Service
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);

        IEnumerable<Owner> GetAllOwners(Filter filter = null);

        Owner UpdateOwner(Owner updatedOwner);

        Owner DeleteOwner(int id);
        Owner SortById(int id);
        Owner FindOwnerByIdIncludePets(int id);
    }
}
