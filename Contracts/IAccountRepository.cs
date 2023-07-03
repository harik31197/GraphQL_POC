using System.Collections.Generic;
using GraphQL_DotNetCore.Entities;

namespace GraphQL_DotNetCore.Contracts
{
    public interface IAccountRepository
    {        

        IEnumerable<Account> GetAccountsByOwnerId(int ownerId);

        IEnumerable<Account> GetAllAccounts();

        Account GetAccountByType(string accountType);
    }
}
