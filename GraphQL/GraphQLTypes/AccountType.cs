using GraphQL.Types;
using GraphQL_DotNetCore.Entities;

namespace GraphQL_DotNetCore.GraphQL.GraphQLTypes
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x.Id).Description("Id property from the account object.");
            Field(x => x.Description).Description("Description property from the account object.");            
            Field(x => x.Type).Description("Account type for the accounts");            
        }
    }
}
