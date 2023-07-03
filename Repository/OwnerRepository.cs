using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_DotNetCore.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAllOwners() => _context.Owners.ToList();        

        public Owner GetOwnerById(int id) => _context.Owners.SingleOrDefault(o => o.Id.Equals(id));

        public Owner GetOwnerByName(string ownerName) => _context.Owners.FirstOrDefault(o => o.Name.Equals(ownerName));

        public OwnerAccounts CheckOwnerAccounts(OwnerAccountsDetail ownerAccountDet)
        {
            var ownerAccount = new OwnerAccounts
            {
                OwnerId = _context.Owners.SingleOrDefault(p => p.Name.Equals(ownerAccountDet.OwnerName)).Id,

                AccountId = _context.Accounts.SingleOrDefault(p => p.Type.Equals(ownerAccountDet.AccountType)).Id
            };

            return _context.OwnerAccounts.FirstOrDefault(
                e => e.OwnerId == ownerAccount.OwnerId && e.AccountId == ownerAccount.AccountId);
        }

        public OwnerAccounts CheckOwnerLinkExists(string ownerName)
        {
            var ownerId = _context.Owners.SingleOrDefault(c => c.Name.Equals(ownerName)).Id;

            return _context.OwnerAccounts.FirstOrDefault(o => o.OwnerId == ownerId);
        }

        public Owner CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Address = !string.IsNullOrEmpty(owner.Address) ? owner.Address : dbOwner.Address;
            dbOwner.Phone = !string.IsNullOrEmpty(owner.Phone) ? owner.Phone : dbOwner.Phone;
            dbOwner.Email = !string.IsNullOrEmpty(owner.Email) ? owner.Email : dbOwner.Email;
            dbOwner.DOB = owner.DOB != null ? owner.DOB : dbOwner.DOB;

            _context.SaveChanges();
            return dbOwner;
        }

        public void DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }

        public Owner CreateOwnerAccounts(OwnerAccountsDetail ownerAccountDet)
        {
            var ownerAccount = new OwnerAccounts
            {
                OwnerId = _context.Owners.SingleOrDefault(p => p.Name.Equals(ownerAccountDet.OwnerName)).Id,

                AccountId = _context.Accounts.SingleOrDefault(p => p.Type.Equals(ownerAccountDet.AccountType)).Id
            };

            _context.OwnerAccounts.Add(ownerAccount);
            _context.SaveChanges();

            return _context.Owners.FirstOrDefault(i => i.Name == ownerAccountDet.OwnerName);
        }
    }
}