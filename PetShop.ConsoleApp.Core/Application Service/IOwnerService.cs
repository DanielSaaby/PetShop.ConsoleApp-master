using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Core.Application_Service
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);

        List<Owner> GetAllOwners();

        Owner UpdateOwner(Owner ownerToEdit);

        Owner DeleteOwner(int id);

        Owner SortById(int id);
        
        Owner FindOwnerByIdIncludePets(int id);
        List<Owner> GetFilteredOwners(Filter filter);
    }
}
