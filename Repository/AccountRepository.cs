using GraphQL_DotNetCore.Contracts;
using GraphQL_DotNetCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_DotNetCore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;
        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAccountsByOwnerId(int ownerId)
        {
            return _context.OwnerAccounts
                .Join(_context.Accounts, o => o.AccountId, a => a.Id, (o, a) => new { o, a })
                .Where(oa => oa.o.OwnerId.Equals(ownerId))
                .Select(oa => oa.a).ToList();
        }

        public IEnumerable<Account> GetAllAccounts() => _context.Accounts.ToList();

        public Account GetAccountByType(string accountType) 
            => _context.Accounts.FirstOrDefault(a => a.Type.Equals(accountType));
    }
}
