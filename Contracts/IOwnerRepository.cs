using GraphQL_DotNetCore.Entities;
using System;
using System.Collections.Generic;

namespace GraphQL_DotNetCore.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(int id);
        Owner GetOwnerByName(string ownerName);
        OwnerAccounts CheckOwnerAccounts(OwnerAccountsDetail ownerAccountDet);
        OwnerAccounts CheckOwnerLinkExists(string ownerName);

        Owner CreateOwner(Owner owner);
        Owner UpdateOwner(Owner dbOwner, Owner owner);
        void DeleteOwner(Owner owner);
        Owner CreateOwnerAccounts(OwnerAccountsDetail ownerAccountDet);
    }
}
